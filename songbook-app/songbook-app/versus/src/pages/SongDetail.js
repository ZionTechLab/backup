import React, { useState, useEffect } from 'react';
import { useParams, Link, useNavigate } from 'react-router-dom';
import { getSongById, getChordVersionsBySongId } from '../data/api';
import './SongDetail.css';

const SongDetail = () => {
  const { songId } = useParams();
  const navigate = useNavigate();
  const [song, setSong] = useState(null);
  const [chordVersions, setChordVersions] = useState([]);

  useEffect(() => {
    const currentSong = getSongById(songId);
    setSong(currentSong);

    if (currentSong) {
      const versions = getChordVersionsBySongId(currentSong.id);
      setChordVersions(versions);
    }
  }, [songId]);

  const handleCompareVersions = () => {
    if (chordVersions.length >= 2) {
      // For simplicity, compare the first two versions.
      // A more robust UI would allow selecting which two.
      navigate(`/songs/${songId}/diff/${chordVersions[0].id}/${chordVersions[1].id}`);
    } else {
      alert("Need at least two versions to compare.");
    }
  };

  if (!song) {
    return <div className="not-found-message">Song not found.</div>;
  }

  return (
    <div className="song-detail-container card">
      <h2 className="song-detail-title">{song.title}</h2>

      <div className="lyrics-section card">
        <h3 className="section-title">Lyrics</h3>
        <pre className="lyrics-text">{song.lyrics}</pre>
      </div>

      {/* Categories Section */}
      {song.categories && song.categories.length > 0 && (
        <div className="categories-section card">
          <h3 className="section-title">Categories</h3>
          <ul className="category-list">
            {song.categories.map(category => (
              <li key={`${category.type_id}-${category.id}`} className="category-item">
                <span className="category-type">{category.type}:</span> {category.name}
              </li>
            ))}
          </ul>
        </div>
      )}

      {chordVersions.length > 0 && (
        <div className="chord-versions-section">
          <div className="section-header-actions">
            <h3 className="section-title">Chord Versions</h3>
            {chordVersions.length >= 2 && (
              <button onClick={handleCompareVersions} className="link-button compare-versions-btn">
                Compare First Two Versions
              </button>
            )}
          </div>
          <ul className="chord-version-list">
            {chordVersions.map(version => (
              <li key={version.id} className="chord-version-item card">
                <Link to={`/songs/${song.id}/versions/${version.id}`} className="chord-version-link">
                  {version.title} (by {version.author || 'Unknown Author'})
                </Link>
              </li>
            ))}
          </ul>
        </div>
      )}
      {chordVersions.length === 0 && <p className="no-versions-message">No chord versions available for this song.</p>}

      <div className="navigation-links">
        <Link to="/" className="link-button">Back to Song List</Link>
      </div>
    </div>
  );
};

export default SongDetail;
