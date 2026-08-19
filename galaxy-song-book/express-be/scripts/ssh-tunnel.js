const { spawn } = require('child_process');
const readline = require('readline');
const path = require('path');

// ── Defaults (edit these to match your setup) ──────────────────────
const DEFAULTS = {
  privateKey: path.join(process.env.USERPROFILE || '~', '.ssh', 'heatwave_key'),
  localPort: '3306',
  extraFlags: '-o IdentitiesOnly=yes -o StrictHostKeyChecking=no',
};

// ── Ask user for input ────────────────────────────────────────────
function ask(query) {
  const rl = readline.createInterface({ input: process.stdin, output: process.stdout });
  return new Promise(resolve => rl.question(query, ans => { rl.close(); resolve(ans.trim()); }));
}

function log(color, msg) {
  const codes = { red: '\x1b[31m', green: '\x1b[32m', yellow: '\x1b[33m', cyan: '\x1b[36m', reset: '\x1b[0m' };
  console.log(`${codes[color] || ''}${msg}${codes.reset}`);
}

function shellQuote(arg) {
  // Wrap in double-quotes on Windows if path has spaces or parens
  if (process.platform === 'win32' && (/\s/.test(arg) || /[()]/.test(arg))) {
    return `"${arg}"`;
  }
  return arg;
}

// ── Main ──────────────────────────────────────────────────────────
(async () => {
  log('cyan', '\n=== SSH Tunnel to MySQL (Bastion) ===\n');

  // 1. Ask the user to paste the bastion command
  const raw = await ask('Paste your bastion SSH command:\n> ');

  if (!raw.trim()) {
    log('red', 'No command provided. Exiting.');
    process.exit(1);
  }

  // 2. Replace placeholders
  let cmd = raw;

  // Placeholder patterns we detect
  const replacements = {
    '<privateKey>': shellQuote(DEFAULTS.privateKey),
    '<private_key>': shellQuote(DEFAULTS.privateKey),
    '<key>': shellQuote(DEFAULTS.privateKey),
    '<localPort>': DEFAULTS.localPort,
    '<local_port>': DEFAULTS.localPort,
    '<port>': DEFAULTS.localPort,
  };

  for (const [placeholder, value] of Object.entries(replacements)) {
    if (cmd.includes(placeholder)) {
      cmd = cmd.replace(new RegExp(placeholder.replace(/[<>]/g, '\\$&'), 'g'), value);
      log('yellow', `  Replaced ${placeholder} → ${value}`);
    }
  }

  // 3. Inject -o flags if not already present
  if (!cmd.includes('IdentitiesOnly')) {
    cmd = cmd.replace(/^(-i\s+\S+)/, `$1 ${DEFAULTS.extraFlags}`);
  }

  // 4. Show the final command and confirm
  log('green', `\nFinal command:\n  ${cmd}\n`);

  const confirm = await ask('Run this tunnel? (y/n): ');
  if (confirm.toLowerCase() !== 'y') {
    log('red', 'Cancelled.');
    process.exit(0);
  }

  // 5. Parse into argv and spawn
  log('cyan', '\nStarting tunnel... (Press Ctrl+C to stop)\n');

  // Simple shell-arg parser: split on spaces but keep quoted strings together
  const args = [];
  let current = '';
  let inQuote = false;
  for (const ch of cmd) {
    if (ch === '"') { inQuote = !inQuote; continue; }
    if (ch === ' ' && !inQuote) {
      if (current) { args.push(current); current = ''; }
    } else {
      current += ch;
    }
  }
  if (current) args.push(current);

  // Strip leading 'ssh' if present in the command string (we use it as the binary)
  const binary = args[0] === 'ssh' ? args.shift() : 'ssh';

  const child = spawn(binary, args, { stdio: 'inherit', shell: true });

  child.on('error', (err) => {
    log('red', `Failed to start: ${err.message}`);
    process.exit(1);
  });

  child.on('exit', (code) => {
    log(code === 0 ? 'green' : 'red', `Tunnel closed (exit ${code}).`);
    process.exit(code);
  });
})();
