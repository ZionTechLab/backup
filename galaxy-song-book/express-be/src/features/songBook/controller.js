const { updateSchema, deleteSchema } = require('./validation');
const repo = require('./repository');
const asyncHandler = require('../../middleware/asyncHandler');
const { AppError } = require('../../middleware/errorHandler');
const { VALIDATE_OPTS } = require('../../middleware/validation');

exports.getAllBooks = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const books = await repo.getAllBooks(filters);
  res.json(books);
});

exports.getBook = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const book = await repo.getBook(filters);
  if (!book) throw new AppError('Not found', 404);
  res.json(book);
});


exports.getPopularSongs = asyncHandler(async (req, res) => {
  const limit = parseInt(req.query.limit, 10) || 10;
  const songs = await repo.getPopularSongs(limit);
  res.json(songs);
});

exports.getAllSongs = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const songs = await repo.getAllSongs(filters);
  res.json(songs);
});

exports.getSong = asyncHandler(async (req, res) => {
  const filters = Object.keys(req.query || {}).length ? req.query : (req.body || {});
  const song = await repo.getSong(filters);
  if (!song) throw new AppError('Not found', 404);
  res.json(song);
});

exports.updateSong = asyncHandler(async (req, res) => {
  const data = await updateSchema.validate(req.body, VALIDATE_OPTS);
  const song = await repo.updateSong({ ...data, userId: req.userId });
  res.status(201).json(song);
});

exports.deleteSong = asyncHandler(async (req, res) => {
  const data = await deleteSchema.validate(req.body, VALIDATE_OPTS);
  await repo.deleteSong({ ...data, userId: req.userId });
  res.json({ success: true });
});
