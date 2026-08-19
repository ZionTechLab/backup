// White-label brand config. One brand per deployment.
// To rebrand: edit the values here, drop assets into public/brand/, and update
// public/manifest.json for the PWA name and icons. No rebuild logic, no DB.

export const brand = {
  // Identity
  name: 'Galaxy Song Book',
  sub: 'Song Registration · v1.0',
  logoMark: 'G',          // letter mark used when `logo` is empty
  logo: '/brand/galaxy-logo.png',
  favicon: '/brand/galaxy-logo.png',

  // Color. Blank keeps the Galaxy token default. Any hex overrides --ml-primary.
  primaryColor: '',

  // Login page copy
  login: {
    eyebrow: 'Song Registration',
    headline: 'Every song,',
    headlineDim: 'in one book.',
    subhead: 'Register, tag, and track every submission in one place.',
  },

  // Footer and reports
  footerText: '© Galaxy Song Book 2026',
  reportLogo: '',         // optional image path for report and voucher headers
};

// Applies the brand at boot: document title, favicon, and primary color.
// Safe to call once on app start. No-ops for any value left blank.
export function applyBrand() {
  try {
    if (brand.name) document.title = brand.name;

    if (brand.favicon) {
      let link = document.querySelector("link[rel~='icon']");
      if (!link) {
        link = document.createElement('link');
        link.rel = 'icon';
        document.head.appendChild(link);
      }
      link.href = brand.favicon;
    }

    if (brand.primaryColor) {
      const root = document.documentElement;
      root.style.setProperty('--ml-primary', brand.primaryColor);
      root.style.setProperty('--primary-color', brand.primaryColor);
      root.style.setProperty('--bs-primary', brand.primaryColor);
    }
  } catch {
    // boot-time branding must never break the app
  }
}

export default brand;
