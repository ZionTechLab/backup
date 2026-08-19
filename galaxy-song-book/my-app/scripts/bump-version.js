#!/usr/bin/env node
/**
 * Simple multi-package version bumper.
 * Usage:
 *   node scripts/bump-version.js [patch|minor|major] [packageName]
 * Defaults:
 *   type = patch
 *   packageName (workspace) = ravonix-components (if provided) else root
 * Behavior:
 *   - If packageName provided (matches a workspace folder name) bump that package only
 *   - Always keeps root package.json version in sync with app version (optional; controlled by syncRoot flag)
 */
const fs = require('fs');
const path = require('path');

const releaseType = (process.argv[2] || 'patch').toLowerCase();
const targetPackage = process.argv[3];
const allowed = ['patch', 'minor', 'major'];
if (!allowed.includes(releaseType)) {
  console.error(`Invalid release type '${releaseType}'. Use one of: ${allowed.join(', ')}`);
  process.exit(1);
}

// Root directory is two levels up from this script file (scripts/)
const rootDir = path.resolve(__dirname, '..');
const rootPkgPath = path.join(rootDir, 'package.json');
const rootPkg = JSON.parse(fs.readFileSync(rootPkgPath, 'utf8'));

// Discover workspaces (simple glob: packages/*)
const workspacesDir = path.join(rootDir, 'packages');
let workspacePkgs = [];
if (fs.existsSync(workspacesDir)) {
  workspacePkgs = fs.readdirSync(workspacesDir)
    .filter(name => fs.existsSync(path.join(workspacesDir, name, 'package.json')))
    .map(name => ({ name, pkgPath: path.join(workspacesDir, name, 'package.json') }));
}

function bumpVersion(version, type) {
  const parts = version.split('.').map(n => parseInt(n, 10));
  while (parts.length < 3) parts.push(0); // ensure x.y.z
  if (type === 'major') { parts[0] += 1; parts[1] = 0; parts[2] = 0; }
  else if (type === 'minor') { parts[1] += 1; parts[2] = 0; }
  else { parts[2] += 1; }
  return parts.join('.');
}

function updatePackage(pkgPath) {
  const pkg = JSON.parse(fs.readFileSync(pkgPath, 'utf8'));
  const oldVersion = pkg.version || '0.0.0';
  const newVersion = bumpVersion(oldVersion, releaseType);
  pkg.version = newVersion;
  fs.writeFileSync(pkgPath, JSON.stringify(pkg, null, 2) + '\n');
  return { oldVersion, newVersion, name: pkg.name };
}

let updated = [];
if (targetPackage) {
  const match = workspacePkgs.find(w => w.name === targetPackage);
  if (!match) {
    console.error(`Package '${targetPackage}' not found under packages/`);
    process.exit(1);
  }
  updated.push(updatePackage(match.pkgPath));
} else {
  // Default: bump root app version only
  updated.push(updatePackage(rootPkgPath));
}

// If we bumped a workspace package, optionally sync dependency reference in root if present
for (const info of updated) {
  if (info.name && rootPkg.dependencies && rootPkg.dependencies[info.name]) {
    rootPkg.dependencies[info.name] = `^${info.newVersion}`;
  }
}
// Only write root if changed (either we bumped root or dependency versions changed)
const rootChanged = updated.some(u => u.name === rootPkg.name) || updated.some(u => rootPkg.dependencies && rootPkg.dependencies[u.name] === `^${u.newVersion}`);
if (rootChanged) {
  // If root itself was not bumped but dependencies updated, keep its own version constant
  fs.writeFileSync(rootPkgPath, JSON.stringify(rootPkg, null, 2) + '\n');
}