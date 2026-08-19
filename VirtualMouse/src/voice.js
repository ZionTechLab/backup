// Step 2: voice command loop.
// Windows System.Speech sidecar -> intent map -> mouse.js (same core as the CLI).
import { spawn } from "node:child_process";
import readline from "node:readline";
import path from "node:path";
import { fileURLToPath } from "node:url";
import * as m from "./mouse.js";

const __dirname = path.dirname(fileURLToPath(import.meta.url));
const scriptPath = path.join(__dirname, "..", "speech", "recognizer.ps1");

const STEP = 40; // px per movement nudge
const MIN_CONFIDENCE = 0.5; // ignore shaky recognitions
let asleep = false;

// Spoken phrase -> mouse action.
const actions = {
  "click": () => m.leftClick(),
  "right click": () => m.rightClick(),
  "double click": () => m.doubleClick(),
  "move up": () => m.moveBy(0, -STEP),
  "move down": () => m.moveBy(0, STEP),
  "move left": () => m.moveBy(-STEP, 0),
  "move right": () => m.moveBy(STEP, 0),
  "scroll up": () => m.scroll("up"),
  "scroll down": () => m.scroll("down"),
};

async function handle(text, confidence) {
  // Sleep/wake is the hands-free safety switch. Always honored.
  if (text === "wake up") {
    asleep = false;
    console.log("[awake]");
    return;
  }
  if (text === "go to sleep") {
    asleep = true;
    console.log("[asleep] say 'wake up' to resume");
    return;
  }
  if (asleep) return;

  if (confidence < MIN_CONFIDENCE) {
    console.log(`  ignored, low confidence ${confidence}: ${text}`);
    return;
  }
  const fn = actions[text];
  if (!fn) return;
  console.log(`> ${text} (${confidence})`);
  try {
    await fn();
  } catch (e) {
    console.error("  error:", e.message);
  }
}

const child = spawn(
  "powershell.exe",
  ["-NoProfile", "-NonInteractive", "-ExecutionPolicy", "Bypass", "-File", scriptPath],
  { windowsHide: true }
);
console.log("starting recognizer... first start takes a few seconds.");

child.on("error", (e) => {
  console.error("failed to start recognizer:", e.message);
  process.exit(1);
});

const rl = readline.createInterface({ input: child.stdout });
rl.on("line", (line) => {
  line = line.trim();
  if (!line) return;
  let msg;
  try {
    msg = JSON.parse(line);
  } catch {
    return; // ignore non-JSON noise
  }
  if (msg.type === "ready") {
    console.log("listening. speak a command.");
    console.log("try: click | right click | double click | move up/down/left/right | scroll up/down");
    console.log("say 'go to sleep' to pause, 'wake up' to resume. ctrl+c to quit.");
  } else if (msg.type === "cmd") {
    handle(msg.text, msg.confidence);
  } else if (msg.type === "error") {
    console.error("recognizer error:", msg.message);
  }
});

child.stderr.on("data", (d) => console.error("ps:", d.toString().trim()));
child.on("exit", (code) => {
  console.log(`recognizer exited (${code})`);
  process.exit(code ?? 0);
});
process.on("SIGINT", () => {
  child.kill();
  process.exit(0);
});
