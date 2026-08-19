// Simple axios mock for Jest to avoid ESM parsing issues in CRA tests.
const mockAxios = {
	create: () => mockAxios,
	get: jest.fn(() => Promise.resolve({ data: {} })),
	post: jest.fn(() => Promise.resolve({ data: {} })),
	put: jest.fn(() => Promise.resolve({ data: {} })),
	delete: jest.fn(() => Promise.resolve({ data: {} })),
	interceptors: { request: { use: jest.fn() }, response: { use: jest.fn() } },
};

export default mockAxios;