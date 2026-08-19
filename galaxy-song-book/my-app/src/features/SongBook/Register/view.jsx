import { useState, useEffect, useCallback } from "react";
import { useSelector } from "react-redux";
import { selectIsLoggedIn } from "../../auth/authSlice";
import QRCode from "react-qr-code";
import { useParams, useNavigate } from "react-router-dom";
import ApiService from "./service";
import MessageBoxService from "../../../services/MessageBoxService";
import ReactMarkdown from "react-markdown";
import rehypeRaw from "rehype-raw";
import rehypeSanitize from "rehype-sanitize";
import "../SongBook.css";

function RegisterPage() {
  const { id } = useParams();
  const navigate = useNavigate();
  const [song, setSong] = useState(null);
  const [showQR, setShowQR] = useState(false);
  const isLoggedIn = useSelector(selectIsLoggedIn);

  useEffect(() => {
    if (id) {
      const fetchSong = async () => {
        const response = await ApiService.get(id);
        if (response.success && response.data) {
          setSong(response.data);
        }
      };
      fetchSong();
    }
  }, [id]);

  const handleNav = useCallback((direction) => {
    if (!id) return;
    const nextId = parseInt(id, 10) + direction;
    if (nextId >= 1) {
      navigate(`/song-book/song/view/${nextId}`);
    }
  }, [id, navigate]);

  useEffect(() => {
    const handleKey = (e) => {
      if (e.key === 'ArrowLeft') handleNav(-1);
      if (e.key === 'ArrowRight') handleNav(1);
    };
    window.addEventListener('keydown', handleKey);
    return () => window.removeEventListener('keydown', handleKey);
  }, [handleNav]);

  const handleShare = async () => {
    if (navigator.share) {
      try {
        await navigator.share({
          title: song?.title || "Song Lyrics",
          url: window.location.href,
        });
      } catch (error) {
      }
    } else {
      try {
        await navigator.clipboard.writeText(window.location.href);
        MessageBoxService.show({ message: "Link copied to clipboard!", type: "success" });
      } catch (err) {
      }
    }
  };

  if (!song) return null;

  return (
    <>
      <div className="songbook-page">
        {/* Header */}
        <div className="songbook-header">
          <div className="songbook-hymn-no">&middot; Hymn No. {song.id} &middot;</div>
          <h1 className="songbook-title">{song.title}</h1>
          <div className="hw-ornament">
          <div className="hw-orn-line"></div>
          <div className="hw-orn-diamond"></div>
          <div className="hw-orn-line"></div>
          </div>
        </div>

        {/* Lyrics */}
        <div className="songbook-lyrics">
          <ReactMarkdown rehypePlugins={[rehypeRaw, rehypeSanitize]}>
            {song.lyrics}
          </ReactMarkdown>
        </div>

        {/* Bottom nav */}
        <div className="songbook-nav">
          <button
            className="songbook-nav-btn"
            onClick={() => handleNav(-1)}
            disabled={parseInt(id, 10) <= 1}
          >
            <i className="bi bi-chevron-left"></i>
          </button>

          <button
            className="songbook-nav-btn"
            onClick={() => navigate("/song-book/all")}
          >
            <i className="bi bi-grid-3x3-gap"></i> 
          </button>
     <button className="songbook-nav-btn" onClick={() => navigate('/song-book/settings')} title="Settings">
              <i className="bi bi-gear"></i>
            </button>
       
     <button className="songbook-nav-btn" onClick={() => setShowQR(true)} title="QR Code">
              <i className="bi bi-qr-code"></i>
            </button>
            <button className="songbook-nav-btn" onClick={handleShare} title="Share">
              <i className="bi bi-share"></i>
            </button>
            {isLoggedIn && (
              <button className="songbook-nav-btn" onClick={() => navigate(`/song-book/song/edit/${song.id}`)} title="Edit Song">
                <i className="bi bi-pencil"></i>
              </button>
              
            )}   <button
            className="songbook-nav-btn"
            onClick={() => handleNav(1)}
          >
         <i className="bi bi-chevron-right"></i>
          </button>
        </div>
      </div>

      {/* QR Fullscreen overlay */}
      {showQR && (
        <div className="songbook-qr-overlay" onClick={() => setShowQR(false)}>
          <div className="songbook-qr-content" onClick={(e) => e.stopPropagation()}>
            <QRCode value={window.location.href} size={220} />
            <p className="mt-3 mb-1 fw-semibold">{song.title}</p>
            <p className="text-muted small mb-3">Scan to open this hymn</p>
            <button className="btn btn-sm btn-outline-secondary" onClick={() => setShowQR(false)}>
              Close
            </button>
          </div>
        </div>
      )}
    </>
  );
}

export default RegisterPage;
