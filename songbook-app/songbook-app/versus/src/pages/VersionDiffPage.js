import React, { useState, useEffect } from 'react';
import { useParams, Link } from 'react-router-dom';
import { getChordVersionById, getSongById } from '../data/api';
import './VersionDiffPage.css'; // Create this CSS file

// Basic diff function (line by line)
const simpleLineDiff = (text1, text2) => {
  const lines1 = text1.split('\\n');
  const lines2 = text2.split('\\n');
  const maxLength = Math.max(lines1.length, lines2.length);
  const diffResult = [];

  for (let i = 0; i < maxLength; i++) {
    const line1 = lines1[i];
    const line2 = lines2[i];

    if (line1 === undefined) { // Line added in text2
      diffResult.push({ type: 'added', line: line2 });
    } else if (line2 === undefined) { // Line removed in text1
      diffResult.push({ type: 'removed', line: line1 });
    } else if (line1 !== line2) { // Line changed
      // For simplicity, show both, mark as changed. More advanced would be char diff.
      diffResult.push({ type: 'changed', line1: line1, line2: line2 });
    } else { // Line is the same
      diffResult.push({ type: 'same', line: line1 });
    }
  }
  return diffResult;
};


const VersionDiffPage = () => {
  const { songId, versionId1, versionId2 } = useParams();
  const [song, setSong] = useState(null);
  const [version1, setVersion1] = useState(null);
  const [version2, setVersion2] = useState(null);
  const [diff, setDiff] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      const currentSong = getSongById(songId);
      setSong(currentSong);

      const v1 = getChordVersionById(versionId1, songId);
      const v2 = getChordVersionById(versionId2, songId);

      setVersion1(v1);
      setVersion2(v2);

      if (v1 && v2) {
        setDiff(simpleLineDiff(v1.chords, v2.chords));
      }
      setLoading(false);
    };
    fetchData();
  }, [songId, versionId1, versionId2]);

  if (loading) {
    return <div className="container card loading-message">Loading version comparison...</div>;
  }

  if (!song || !version1 || !version2) {
    return <div className="container card not-found-message">One or both versions not found.</div>;
  }

  return (
    <div className="version-diff-page container card">
      <h2 className="page-title">
        Compare Versions for "{song.title}"
      </h2>
      <div className="version-titles">
        <h3 className="version-title-1">{version1.title} (by {version1.author})</h3>
        <h3 className="version-title-2">{version2.title} (by {version2.author})</h3>
      </div>

      <div className="diff-display">
        {/* This simple version will interleave lines. A side-by-side would be more complex. */}
        <pre className="diff-content">
          {diff.map((item, index) => {
            if (item.type === 'added') {
              return <div key={index} className="diff-line diff-added"><span className="marker">+</span> {item.line}</div>;
            }
            if (item.type === 'removed') {
              return <div key={index} className="diff-line diff-removed"><span className="marker">-</span> {item.line}</div>;
            }
            if (item.type === 'changed') {
              return (
                <React.Fragment key={index}>
                  <div className="diff-line diff-removed"><span className="marker">-</span> {item.line1}</div>
                  <div className="diff-line diff-added"><span className="marker">+</span> {item.line2}</div>
                </React.Fragment>
              );
            }
            // item.type === 'same'
            return <div key={index} className="diff-line diff-same"><span className="marker"> </span> {item.line}</div>;
          })}
        </pre>
      </div>
      <div className="navigation-links" style={{ marginTop: '20px' }}>
        <Link to={`/songs/${songId}`} className="link-button">Back to Song Details</Link>
      </div>
    </div>
  );
};

export default VersionDiffPage;
