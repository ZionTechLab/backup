// Step 1 CLI. Drive the pointer by hand to prove control works.
// Run interactive:  npm start
// One-shot:         node src/cli.js move 500 500
import readline from "node:readline";
import * as m from "./mouse.js";

const help = `commands:
  pos                      show pointer position
  move <x> <y>             move to absolute position
  by <dx> <dy>             move relative to current
  left | right | double    click
  scroll <up|down|left|right> [amount]
  help                     this list
  exit                     quit`;

const commands = {
  pos: async () => {
    const p = await m.getPosition();
    console.log(`x=${p.x} y=${p.y}`);
  },
  move: async (x, y) => {
    await m.moveTo(Number(x), Number(y));
    await commands.pos();
  },
  by: async (dx, dy) => {
    await m.moveBy(Number(dx), Number(dy));
    await commands.pos();
  },
  left: async () => {
    await m.leftClick();
    console.log("left click");
  },
  right: async () => {
    await m.rightClick();
    console.log("right click");
  },
  double: async () => {
    await m.doubleClick();
    console.log("double click");
  },
  scroll: async (dir, amount) => {
    await m.scroll(dir, amount ? Number(amount) : 3);
    console.log(`scroll ${dir}`);
  },
  help: async () => console.log(help),
};

async function run(line) {
  const [cmd, ...args] = line.trim().split(/\s+/);
  if (!cmd) return;
  if (cmd === "exit" || cmd === "quit") process.exit(0);
  const fn = commands[cmd];
  if (!fn) {
    console.log(`unknown: ${cmd} (try help)`);
    return;
  }
  try {
    await fn(...args);
  } catch (e) {
    console.error("error:", e.message);
  }
}

const argv = process.argv.slice(2);
if (argv.length) {
  run(argv.join(" ")).then(() => process.exit(0));
} else {
  console.log("virtual-mouse cli. type help.");
  const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
    prompt: "> ",
  });
  rl.prompt();
  rl.on("line", async (line) => {
    await run(line);
    rl.prompt();
  });
  rl.on("close", () => process.exit(0));
}
