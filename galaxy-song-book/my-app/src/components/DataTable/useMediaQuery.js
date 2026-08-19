import { useState, useEffect } from 'react';

// Subscribe to a CSS media query. Returns whether it currently matches and
// updates on viewport changes. Shared by the table (card breakpoint) and the
// pagination (compact page-number breakpoint).
export function useMediaQuery(query) {
  const [matches, setMatches] = useState(
    typeof window !== 'undefined' ? window.matchMedia(query).matches : false
  );

  useEffect(() => {
    const mq = window.matchMedia(query);
    const handler = (e) => setMatches(e.matches);
    setMatches(mq.matches);
    mq.addEventListener('change', handler);
    return () => mq.removeEventListener('change', handler);
  }, [query]);

  return matches;
}
