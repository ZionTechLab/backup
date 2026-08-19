import initialSongsData from './songs.json';
import initialCategoriesData from './categories.json'; // Renamed for clarity
import initialCategoryTypesData from './category_types.json'; // Renamed for clarity
import initialSongCategoriesData from './song_categories.json'; // Import new junction data
import initialChordVersionsData from './chord_versions.json';
import userData from './user.json';
import teamsData from './teams.json';

// In-memory store, initialized from JSONs
let songsStore = JSON.parse(JSON.stringify(initialSongsData)); // Deep copy
let categoriesStore = JSON.parse(JSON.stringify(initialCategoriesData)); // Deep copy, assuming static for now but good practice
let categoryTypesStore = JSON.parse(JSON.stringify(initialCategoryTypesData)); // Deep copy, assuming static for now
let songCategoriesStore = JSON.parse(JSON.stringify(initialSongCategoriesData)); // Deep copy
let chordVersionsStore = JSON.parse(JSON.stringify(initialChordVersionsData)); // Deep copy

let nextSongId = songsStore.reduce((maxId, song) => Math.max(maxId, song.id), 0) + 1;
let nextChordVersionId = chordVersionsStore.reduce((maxId, cv) => Math.max(maxId, cv.id), 0) + 1;
// let nextCategoryId = categoriesStore.reduce((maxId, cat) => Math.max(maxId, cat.id), 0) + 1; // If we allow adding categories
// let nextCategoryTypeId = categoryTypesStore.reduce((maxId, ct) => Math.max(maxId, ct.id), 0) + 1; // If we allow adding types

// Helper function to get category details
export const getCategoryById = (id) => {
  const catIdInt = parseInt(id);
  return categoriesStore.find(cat => cat.id === catIdInt);
};

// Helper function to get category type details
export const getCategoryTypeById = (id) => {
  const catTypeIdInt = parseInt(id);
  return categoryTypesStore.find(ct => ct.id === catTypeIdInt);
};

// Get all categories for a specific song
export const getCategoriesForSong = (songId) => {
  const songIdInt = parseInt(songId);
  const categoryLinks = songCategoriesStore.filter(sc => sc.song_id === songIdInt);
  return categoryLinks.map(link => {
    const category = getCategoryById(link.category_id);
    if (category) {
      const categoryType = getCategoryTypeById(category.category_type_id);
      return {
        id: category.id,
        name: category.name,
        type: categoryType ? categoryType.name : 'Unknown Type',
        type_id: category.category_type_id,
      };
    }
    return null;
  }).filter(Boolean); // Remove any nulls if a category wasn't found
};

// Get a single song by ID, now with its categories
export const getSongById = (id) => {
  const songIdInt = parseInt(id);
  const song = songsStore.find(s => s.id === songIdInt);
  if (song) {
    return {
      ...song,
      categories: getCategoriesForSong(songIdInt),
    };
  }
  return undefined;
};

// Get all songs, now with their categories
export const getAllSongs = () => {
  return songsStore.map(song => ({
    ...song,
    categories: getCategoriesForSong(song.id),
  }));
};

export const getAllCategories = () => {
  // Optionally, enrich categories with their type names
  return categoriesStore.map(cat => {
    const type = getCategoryTypeById(cat.category_type_id);
    return { ...cat, type_name: type ? type.name : "Unknown" };
  });
};

export const getAllCategoryTypes = () => {
  return [...categoryTypesStore]; // Return a copy
};

export const getAllChordVersions = () => {
  return [...chordVersionsStore]; // Return a copy
};

export const getChordVersionsBySongId = (songId) => {
  const songIdInt = parseInt(songId);
  return chordVersionsStore.filter(cv => cv.song_id === songIdInt);
};

export const getChordVersionById = (versionId, songId) => {
  const versionIdInt = parseInt(versionId);
  const songIdInt = parseInt(songId);
  return chordVersionsStore.find(cv => cv.id === versionIdInt && cv.song_id === songIdInt);
};

// User data (assuming static for now)
export const getUserData = () => {
  return userData;
};

// Teams data (assuming static for now)
export const getAllTeams = () => {
  return teamsData;
};

export const getTeamsByUserId = (userId) => {
  if (!userId) return [];
  return teamsData.filter(team => team.members.includes(userId));
};

// --- Functions to simulate "saving" new data ---

export const addSong = (songData, categoryIds = []) => {
  const newSongCore = {
    title: songData.title,
    lyrics: songData.lyrics,
    // any other core song fields from songData, but not categories
    id: nextSongId++, // Assign new ID and increment
  };
  songsStore.push(newSongCore);

  // Add category associations
  categoryIds.forEach(catId => {
    // Ensure the category ID is valid before adding (optional, but good practice)
    const categoryExists = categoriesStore.find(c => c.id === parseInt(catId));
    if (categoryExists) {
      songCategoriesStore.push({ song_id: newSongCore.id, category_id: parseInt(catId) });
    } else {
      console.warn(`Category ID ${catId} not found while adding song ${newSongCore.title}. Skipping this category.`);
    }
  });

  console.log("Song added (in-memory):", getSongById(newSongCore.id)); // Log the full song with categories
  // console.log("Current songsStore:", songsStore);
  // console.log("Current songCategoriesStore:", songCategoriesStore);
  return getSongById(newSongCore.id); // Return the created song with its ID and categories
};

export const addCategoryToSong = (songId, categoryId) => {
  const songIdInt = parseInt(songId);
  const categoryIdInt = parseInt(categoryId);

  const song = songsStore.find(s => s.id === songIdInt);
  const category = categoriesStore.find(c => c.id === categoryIdInt);

  if (!song) {
    console.error(`addCategoryToSong: Song with ID ${songIdInt} not found.`);
    return false;
  }
  if (!category) {
    console.error(`addCategoryToSong: Category with ID ${categoryIdInt} not found.`);
    return false;
  }

  const existingLink = songCategoriesStore.find(
    sc => sc.song_id === songIdInt && sc.category_id === categoryIdInt
  );

  if (existingLink) {
    console.warn(`addCategoryToSong: Link between song ${songIdInt} and category ${categoryIdInt} already exists.`);
    return true; // Or false, depending on desired behavior for duplicates
  }

  songCategoriesStore.push({ song_id: songIdInt, category_id: categoryIdInt });
  console.log(`Category ${categoryIdInt} added to song ${songIdInt}.`);
  return true;
};

export const removeCategoryFromSong = (songId, categoryId) => {
  const songIdInt = parseInt(songId);
  const categoryIdInt = parseInt(categoryId);
  const initialLength = songCategoriesStore.length;

  songCategoriesStore = songCategoriesStore.filter(
    sc => !(sc.song_id === songIdInt && sc.category_id === categoryIdInt)
  );

  if (songCategoriesStore.length < initialLength) {
    console.log(`Category ${categoryIdInt} removed from song ${songIdInt}.`);
    return true;
  }
  console.warn(`removeCategoryFromSong: Link between song ${songIdInt} and category ${categoryIdInt} not found.`);
  return false;
};


export const addChordVersion = (versionData) => {
  const newVersion = {
    ...versionData,
    id: nextChordVersionId++, // Assign new ID and increment
  };
  chordVersionsStore.push(newVersion);
  console.log("Chord version added (in-memory):", newVersion);
  return newVersion;
};

// Function to reset data for testing or if needed (not for production use with real backend)
export const resetInMemoryStores = () => {
    songsStore = JSON.parse(JSON.stringify(initialSongsData));
    categoriesStore = JSON.parse(JSON.stringify(initialCategoriesData));
    categoryTypesStore = JSON.parse(JSON.stringify(initialCategoryTypesData));
    songCategoriesStore = JSON.parse(JSON.stringify(initialSongCategoriesData));
    chordVersionsStore = JSON.parse(JSON.stringify(initialChordVersionsData));

    nextSongId = songsStore.reduce((maxId, song) => Math.max(maxId, song.id), 0) + 1;
    nextChordVersionId = chordVersionsStore.reduce((maxId, cv) => Math.max(maxId, cv.id), 0) + 1;
    // Reset other IDs if we were to allow adding new categories/types
    // nextCategoryId = categoriesStore.reduce((maxId, cat) => Math.max(maxId, cat.id), 0) + 1;
    // nextCategoryTypeId = categoryTypesStore.reduce((maxId, ct) => Math.max(maxId, ct.id), 0) + 1;
    console.log("In-memory stores have been reset to initial data.");
};
