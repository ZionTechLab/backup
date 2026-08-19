import { useEffect, useState, useCallback } from 'react';
import { useSearchParams } from 'react-router-dom';
import ReactMarkdown from 'react-markdown';
import remarkGfm from 'remark-gfm';
import MeridianPage from '../Meridian/MeridianPage';
import './Help.css';

const DEFAULT_TOPIC = 'index.md';

// Relative .md links inside help content (e.g. "getting-started.md" or
// "./petty-cash.md") switch the topic in place instead of navigating the
// browser to a raw markdown file. Anything else (http(s) links, mailto)
// opens normally in a new tab.
function makeLinkRenderer(onTopicLink) {
  return function LinkRenderer({ href, children, ...props }) {
    const isRelativeMd = href && !/^([a-z]+:)?\/\//i.test(href) && href.replace(/^\.\//, '').endsWith('.md');
    if (isRelativeMd) {
      const file = href.replace(/^\.\//, '');
      return (
        <a href={`?topic=${file}`} onClick={(e) => { e.preventDefault(); onTopicLink(file); }} {...props}>
          {children}
        </a>
      );
    }
    return <a href={href} target="_blank" rel="noreferrer" {...props}>{children}</a>;
  };
}

export default function Help() {
  const [searchParams, setSearchParams] = useSearchParams();
  const topic = searchParams.get('topic') || DEFAULT_TOPIC;
  const [manifest, setManifest] = useState([]);
  const [content, setContent] = useState('');
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    fetch('/help/manifest.json').then((r) => (r.ok ? r.json() : [])).then(setManifest).catch(() => setManifest([]));
  }, []);

  useEffect(() => {
    setLoading(true);
    setError('');
    fetch(`/help/${topic}`)
      .then((r) => {
        if (!r.ok) throw new Error('not found');
        return r.text();
      })
      .then(setContent)
      .catch(() => setError('This help topic could not be found.'))
      .finally(() => setLoading(false));
  }, [topic]);

  const goToTopic = useCallback((file) => setSearchParams({ topic: file }), [setSearchParams]);

  const linkRenderer = makeLinkRenderer(goToTopic);

  return (
    <MeridianPage title="Help">
      <div className="ml-help-layout">
        <nav className="ml-help-sidebar">
          {manifest.map((t) => (
            <button
              key={t.file}
              className={`ml-help-nav-item${topic === t.file ? ' ml-help-nav-active' : ''}`}
              onClick={() => goToTopic(t.file)}
            >
              {t.title}
            </button>
          ))}
        </nav>
        <div className="ml-help-content">
          {loading ? (
            <div className="text-muted small">Loading...</div>
          ) : error ? (
            <div className="alert alert-warning">{error}</div>
          ) : (
            <ReactMarkdown remarkPlugins={[remarkGfm]} components={{ a: linkRenderer }}>
              {content}
            </ReactMarkdown>
          )}
        </div>
      </div>
    </MeridianPage>
  );
}
