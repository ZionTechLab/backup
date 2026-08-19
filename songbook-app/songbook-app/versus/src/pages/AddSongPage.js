import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { getAllCategories, getAllCategoryTypes, addSong } from '../data/api';
import ChordEditor from '../components/ChordEditor';
import './AddSongPage.css';

const AddSongPage = () => {
  const [title, setTitle] = useState('');
  const [baseLyrics, setBaseLyrics] = useState('');
  const [lyricsAreValid, setLyricsAreValid] = useState(true);

  const [allCategoryTypes, setAllCategoryTypes] = useState([]);
  const [allCategories, setAllCategories] = useState([]);
  const [selectedCategories, setSelectedCategories] = useState({}); // Stores { categoryTypeId: categoryId }

  const navigate = useNavigate();

  useEffect(() => {
    const types = getAllCategoryTypes();
    const categories = getAllCategories(); // This now includes type_name
    setAllCategoryTypes(types);
    setAllCategories(categories);

    // Initialize selectedCategories with default empty selection for each type
    const initialSelected = {};
    types.forEach(type => {
      // Optionally, pre-select the first available category for each type or leave empty
      // For simplicity, we'll leave it empty or user must select.
      // Or, for 'Language', we can pre-select the first language.
      const categoriesForType = categories.filter(cat => cat.category_type_id === type.id);
      if (type.name.toLowerCase() === 'language' && categoriesForType.length > 0) {
        initialSelected[type.id] = categoriesForType[0].id.toString();
      } else {
        initialSelected[type.id] = ''; // No selection or an empty string for "Select..." option
      }
    });
    setSelectedCategories(initialSelected);
  }, []);

  const handleLyricsChange = (text, isValid) => {
    setBaseLyrics(text);
    setLyricsAreValid(isValid);
  };

  const handleCategoryChange = (categoryTypeId, categoryId) => {
    setSelectedCategories(prev => ({
      ...prev,
      [categoryTypeId]: categoryId,
    }));
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    if (!title.trim()) {
      alert('Song title is required.');
      return;
    }
    if (!lyricsAreValid) {
      alert('Please fix bracket errors in lyrics before submitting.');
      return;
    }

    const songCoreData = {
      title: title.trim(),
      lyrics: baseLyrics,
    };

    const categoryIdsToSave = Object.values(selectedCategories).filter(id => id !== '').map(id => parseInt(id));

    // Ensure Language is selected if it's a type (as an example of a required category type)
    const languageType = allCategoryTypes.find(ct => ct.name.toLowerCase() === 'language');
    if (languageType && (!selectedCategories[languageType.id] || selectedCategories[languageType.id] === '')) {
        alert('Please select a language.');
        return;
    }

    try {
      const savedSong = addSong(songCoreData, categoryIdsToSave);
      navigate(`/add-chord-version/${savedSong.id}`);
    } catch (error) {
      console.error("Failed to add song:", error);
      alert("Error adding song. See console for details.");
    }
  };

  return (
    <div className="add-song-page container card">
      <h2 className="page-title">Add New Song</h2>
      <form onSubmit={handleSubmit} className="add-song-form">
        <div className="form-group">
          <label htmlFor="title">Song Title:</label>
          <input
            type="text"
            id="title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            required
          />
        </div>

        {allCategoryTypes.map(categoryType => {
          const relevantCategories = allCategories.filter(
            cat => cat.category_type_id === categoryType.id
          );
          if (relevantCategories.length === 0) return null; // Don't render a dropdown if no categories for this type

          return (
            <div className="form-group" key={categoryType.id}>
              <label htmlFor={`category-${categoryType.id}`}>{categoryType.name}:</label>
              <select
                id={`category-${categoryType.id}`}
                value={selectedCategories[categoryType.id] || ''}
                onChange={(e) => handleCategoryChange(categoryType.id, e.target.value)}
                // Make language required as an example
                required={categoryType.name.toLowerCase() === 'language'}
              >
                <option value="">-- Select {categoryType.name} --</option>
                {relevantCategories.map(cat => (
                  <option key={cat.id} value={cat.id.toString()}>
                    {cat.name}
                  </option>
                ))}
              </select>
            </div>
          );
        })}

        <div className="form-group">
          <label htmlFor="baseLyrics">Base Lyrics (ChordPro format recommended):</label>
          <ChordEditor
            initialValue={baseLyrics}
            onContentChange={handleLyricsChange}
            showPreview={true}
          />
          {!lyricsAreValid && <p className="lyrics-validation-error">Fix bracket errors in lyrics.</p>}
        </div>
        <button type="submit" className="link-button" disabled={!lyricsAreValid || !title.trim()}>
          Save Song & Add Chords
        </button>
      </form>
    </div>
  );
};

export default AddSongPage;
