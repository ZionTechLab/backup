const express = require('express');
const router = express.Router();
const Controller = require('./controller');

router.get('/get-all-books', (req, res, next) => {
	/*
		#swagger.tags = ['SongBook']
		#swagger.summary = 'Get all books'
		#swagger.responses[200] = { description: 'Array of book objects' }
	*/
	return Controller.getAllBooks(req, res, next);
});

router.get('/get-book', (req, res, next) => {
	/*
		#swagger.tags = ['SongBook']
		#swagger.summary = 'Get a single book with its pages'
		#swagger.parameters['id'] = { in: 'query', type: 'integer', required: true }
		#swagger.responses[200] = { description: 'Book object with pages array' }
		#swagger.responses[404] = { description: 'Book not found' }
	*/
	return Controller.getBook(req, res, next);
});


router.get('/get-popular-songs', (req, res, next) => {
	/*
		#swagger.tags = ['SongBook']
		#swagger.summary = 'Get popular songs'
		#swagger.parameters['limit'] = { in: 'query', type: 'integer', description: 'Limit number of popular songs (default: 10)' }
		#swagger.responses[200] = { description: 'Array of popular song objects' }
	*/
	return Controller.getPopularSongs(req, res, next);
});

router.get('/get-all-songs', (req, res, next) => {
	/*
		#swagger.tags = ['SongBook']
		#swagger.summary = 'Get all songs'
		#swagger.responses[200] = { description: 'Array of song objects' }
	*/
	return Controller.getAllSongs(req, res, next);
});

router.get('/get-song', (req, res, next) => {
	/*
		#swagger.tags = ['SongBook']
		#swagger.summary = 'Get a single song with lyrics'
		#swagger.parameters['id'] = { in: 'query', type: 'integer', required: true }
		#swagger.responses[200] = { description: 'Song object' }
		#swagger.responses[404] = { description: 'Song not found' }
	*/
	return Controller.getSong(req, res, next);
});

router.post('/update', (req, res, next) => {
	/*
		#swagger.tags = ['SongBook']
		#swagger.summary = 'Create or update a song'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							isUpdate: { type: 'boolean' },
							id:       { type: 'integer' },
							title:    { type: 'string' },
							lyrics:   { type: 'string' },
							language: { type: 'string' }
						},
						example: { isUpdate: false, title: 'Amazing Grace', lyrics: 'Amazing grace...', language: 'EN' }
					}
				}
			}
		}
		#swagger.responses[201] = { description: 'Song created/updated' }
	*/
	return Controller.updateSong(req, res, next);
});

router.post('/delete', (req, res, next) => {
	/*
		#swagger.tags = ['SongBook']
		#swagger.summary = 'Soft-delete a song'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							id:     { type: 'integer' },
							userId: { type: 'integer' }
						},
						required: ['id'],
						example: { id: 1 }
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Song deleted' }
		#swagger.responses[404] = { description: 'Song not found' }
	*/
	return Controller.deleteSong(req, res, next);
});

module.exports = router;
