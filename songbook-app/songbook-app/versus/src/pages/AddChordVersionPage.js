import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getSongById, addChordVersion } from '../data/api';
import { useUser } from '../contexts/UserContext';
import ChordEditor from '../components/ChordEditor';
import './AddChordVersionPage.css';

const AddChordVersionPage = () => {
  const { songId } = useParams();
  const navigate = useNavigate();
  const { user } = useUser(); // To prefill author if desired

  const [song, setSong] = useState(null);
  const [versionTitle, setVersionTitle] = useState('Default');
  const [versionAuthor, setVersionAuthor] = useState('');
  const [chordLyrics, setChordLyrics] = useState('');
  const [lyricsAreValid, setLyricsAreValid] = useState(true);

  useEffect(() => {
    const currentSong = getSongById(parseInt(songId));
    if (currentSong) {
      setSong(currentSong);
      // Pre-fill lyrics from base song lyrics if available and empty
      if (currentSong.lyrics && !chordLyrics) {
        setChordLyrics(currentSong.lyrics);
      }
    } else {
      // Handle song not found, maybe navigate back or show error
      console.error(`Song with ID ${songId} not found.`);
      navigate('/'); // Or to an error page
    }
  }, [songId, navigate, chordLyrics]); // Added chordLyrics to dependencies to avoid re-pre-filling

  useEffect(() => {
    if (user && user.displayName && !versionAuthor) {
      setVersionAuthor(user.displayName); // Pre-fill author from logged-in user
    }
  }, [user, versionAuthor]);


  const handleLyricsChange = (text, isValid) => {
    setChordLyrics(text);
    setLyricsAreValid(isValid);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    if (!versionTitle.trim()) {
      alert('Version title is required.');
      return;
    }
    if (!lyricsAreValid) {
      alert('Please fix bracket errors in chord lyrics before submitting.');
      return;
    }
    if (!chordLyrics.trim()) {
        alert('Chord lyrics cannot be empty.');
        return;
    }

    const newVersionData = {
      song_id: parseInt(songId),
      title: versionTitle.trim(),
      author: versionAuthor.trim() || 'Unknown', // Default if empty
      chords: chordLyrics,
    };

    try {
      const savedVersion = addChordVersion(newVersionData); // api.js handles ID
      // Navigate to the song detail page or the new chord version view
      navigate(`/songs/${songId}/versions/${savedVersion.id}`);
    } catch (error) {
      console.error("Failed to add chord version:", error);
      alert("Error adding chord version. See console for details.");
    }
  };

  if (!song) {
    return <div className="container card">Loading song details or song not found...</div>;
  }

  return (
    <div className="add-chord-version-page container card">
      <h2 className="page-title">Add Chord Version for "{song.title}"</h2>
      <form onSubmit={handleSubmit} className="add-chord-version-form">
        <div className="form-group">
          <label htmlFor="versionTitle">Version Title:</label>
          <input
            type="text"
            id="versionTitle"
            value={versionTitle}
            onChange={(e) => setVersionTitle(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="versionAuthor">Version Author:</label>
          <input
            type="text"
            id="versionAuthor"
            value={versionAuthor}
            onChange={(e) => setVersionAuthor(e.target.value)}
            placeholder="Your name or source"
          />
        </div>
        <div className="form-group">
          <label htmlFor="chordLyrics">Chord Lyrics (ChordPro format):</label>
          <ChordEditor
            initialValue={chordLyrics} // Use pre-filled or empty
            onContentChange={handleLyricsChange}
            showPreview={true}
          />
          {!lyricsAreValid && <p className="lyrics-validation-error">Fix bracket errors in lyrics.</p>}
        </div>
        <button
            type="submit"
            className="link-button"
            disabled={!lyricsAreValid || !versionTitle.trim() || !chordLyrics.trim()}
        >
          Save Chord Version
        </button>
      </form>
    </div>
  );
};

export default AddChordVersionPage;
