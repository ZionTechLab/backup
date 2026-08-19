import imageCompression from 'browser-image-compression';

// Compress a single File using browser-image-compression
export async function compressImageFile(file, opts = {}) {
  const {
    maxWidth = 1600,
    maxHeight = 1600,
    quality = 0.8,
    maxSizeKB, // optional hard cap in KB
    mimeType = 'image/webp',
    fallbackType = 'image/jpeg',
  } = opts;

  const options = {
    maxWidthOrHeight: Math.max(maxWidth, maxHeight),
    initialQuality: quality,
    useWebWorker: true,
    fileType: mimeType,
  };
  if (maxSizeKB && Number(maxSizeKB) > 0) {
    options.maxSizeMB = Math.max(0.05, Number(maxSizeKB) / 1024);
  }

  const renameWithType = (blobLike, originalName) => {
    try {
      const type = blobLike.type || fallbackType;
      const base = (originalName || 'image').replace(/\.[^/.]+$/, '');
      const ext = type.includes('webp') ? 'webp' : type.includes('png') ? 'png' : 'jpg';
      return new File([blobLike], `${base}.${ext}`, { type, lastModified: Date.now() });
    } catch {
      return blobLike; // if File ctor fails, return as-is
    }
  };

  try {
    let out = await imageCompression(file, options);
    if (!out && mimeType !== fallbackType) {
      out = await imageCompression(file, { ...options, fileType: fallbackType });
    }
    if (!out) return file;
    return renameWithType(out, file.name);
  } catch {
    // Fallback: try JPEG once more
    try {
      const out = await imageCompression(file, { ...options, fileType: fallbackType });
      return renameWithType(out, file.name);
    } catch {
      return file;
    }
  }
}

// Compress only items marked as status === 'new' in ImageMultiInputField shape
export async function compressImageItems(items, opts) {
  if (!Array.isArray(items)) return items;

  const out = [];
  for (const item of items) {
    if (item && item.status === 'new' && item.file instanceof File) {
      try {
        const compressed = await compressImageFile(item.file, opts);
        // update preview URL and revoke old
        if (item.src && item.src.startsWith('blob:')) {
          try { URL.revokeObjectURL(item.src); } catch {}
        }
        const newSrc = URL.createObjectURL(compressed);
        out.push({ ...item, file: compressed, src: newSrc });
      } catch {
        out.push(item);
      }
    } else {
      out.push(item);
    }
  }
  return out;
}

const imageCompressionHelper = { compressImageFile, compressImageItems };
export default imageCompressionHelper;
