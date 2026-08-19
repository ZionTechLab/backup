import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getAllSongs } from '../data/api'; // Updated import
import './SongList.css';

const SongList = () => {
  const [songs, setSongs] = useState([]);

  useEffect(() => {
    const loadedSongs = getAllSongs(); // Use new API function
    setSongs(loadedSongs);
  }, []);

  if (songs.length === 0) {
    return <div className="loading-message">Loading songs...</div>;
  }

  return (
    <div className="song-list-container">
      <h2 className="page-title">Song List</h2>
      <ul className="song-list">
        {songs.map(song => (
          <li key={song.id} className="song-list-item card">
            <Link to={`/songs/${song.id}`} className="song-title-link">
              {song.title}
            </Link>
            {/* Display categories */}
            {song.categories && song.categories.length > 0 && (
              <div className="song-categories">
                {song.categories.map(category => (
                  <p key={category.id} className="song-category-item">
                    {category.type}: {category.name}
                  </p>
                ))}
              </div>
            )}
            {(!song.categories || song.categories.length === 0) && (
              <p className="song-category-item">No categories assigned.</p>
            )}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default SongList;
