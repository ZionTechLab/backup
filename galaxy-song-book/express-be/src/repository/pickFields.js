// Whitelist helper to prevent mass assignment.
// Copies only the allowed keys from a user-supplied object, skipping anything
// not explicitly listed (and any key whose value is undefined). Use this instead
// of spreading `...data.header` / `...item` directly into .insert()/.update().
function pickFields(src = {}, allowed = []) {
  const out = {};
  for (const key of allowed) {
    if (src && src[key] !== undefined) out[key] = src[key];
  }
  return out;
}

module.exports = { pickFields };
