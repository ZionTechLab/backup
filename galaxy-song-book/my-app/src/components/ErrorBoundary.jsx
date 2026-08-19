import { Component } from "react";
import PropTypes from "prop-types";

const CHUNK_RELOAD_KEY = "chunk-error-reloaded";

function isChunkLoadError(error) {
  const message = error?.message || "";
  return (
    error?.name === "ChunkLoadError" ||
    /loading chunk .* failed/i.test(message) ||
    /loading css chunk .* failed/i.test(message)
  );
}

class ErrorBoundary extends Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false };
  }

  static getDerivedStateFromError() {
    return { hasError: true };
  }

  componentDidMount() {
    // A stale service-worker-cached shell can reference chunk hashes that no
    // longer exist after a redeploy. Clear the guard on a successful mount so
    // a future stale-chunk error can trigger the auto-reload again.
    sessionStorage.removeItem(CHUNK_RELOAD_KEY);
  }

  componentDidCatch(error, info) {
    if (isChunkLoadError(error) && !sessionStorage.getItem(CHUNK_RELOAD_KEY)) {
      sessionStorage.setItem(CHUNK_RELOAD_KEY, "1");
      window.location.reload();
    }
  }

  render() {
    if (this.state.hasError) {
      return (
        <div className="error-fallback">
          <h2>Something went wrong.</h2>
          <p>Please refresh the page. If the problem persists, contact support.</p>
          <button onClick={() => window.location.reload()}>Refresh page</button>
        </div>
      );
    }
    return this.props.children;
  }
}

ErrorBoundary.propTypes = {
  children: PropTypes.node.isRequired,
};

export default ErrorBoundary;
