import { handleAxiosError } from './axiosErrorHandler';
import MessageBoxService from '../services/MessageBoxService';

// Mock MessageBoxService
jest.mock('../services/MessageBoxService', () => ({
  show: jest.fn(),
}));

describe('handleAxiosError', () => {
  const originalLocation = window.location;

  beforeEach(() => {
    // Reset mocks
    jest.clearAllMocks();

    // Mock window.location
    delete window.location;
    window.location = {
      ...originalLocation,
      pathname: '/',
      href: '',
    };
  });

  afterAll(() => {
    window.location = originalLocation;
  });

  describe('when error.response is present', () => {
    it('handles 409 status code with message', () => {
      const error = {
        response: {
          status: 409,
          data: { message: 'Conflict error' },
        },
      };

      const result = handleAxiosError(error);

      expect(result).toBe(' Conflict error');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: ' Conflict error',
        type: 'warning',
        onClose: null,
      });
    });

    it('handles 409 status code with error property', () => {
      const error = {
        response: {
          status: 409,
          data: { error: 'Conflict error property' },
        },
      };

      const result = handleAxiosError(error);

      expect(result).toBe(' Conflict error property');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: ' Conflict error property',
        type: 'warning',
        onClose: null,
      });
    });

    it('handles 401 status code with message', () => {
      const error = {
        response: {
          status: 401,
          data: { message: 'Unauthorized error' },
        },
      };

      const result = handleAxiosError(error);

      expect(result).toBe(' Unauthorized error');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: ' Unauthorized error',
        type: 'warning',
        onClose: null,
      });
    });

    it('handles 401 status code with error property', () => {
      const error = {
        response: {
          status: 401,
          data: { error: 'Unauthorized error property' },
        },
      };

      const result = handleAxiosError(error);

      expect(result).toBe(' Unauthorized error property');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: ' Unauthorized error property',
        type: 'warning',
        onClose: null,
      });
    });

    it('handles other status codes with data.error', () => {
      const error = {
        response: {
          status: 500,
          data: { error: 'Server error' },
        },
      };

      const result = handleAxiosError(error);

      expect(result).toBe(' Server error');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: ' Server error',
        type: 'danger',
        onClose: null,
      });
    });

    it('handles other status codes with statusText', () => {
      const error = {
        response: {
          status: 502,
          statusText: 'Bad Gateway',
          data: {},
        },
      };

      const result = handleAxiosError(error);

      expect(result).toBe(' Bad Gateway');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: ' Bad Gateway',
        type: 'danger',
        onClose: null,
      });
    });

    it('handles other status codes with fallback message', () => {
      const error = {
        response: {
          status: 503,
          data: {},
        },
      };

      const result = handleAxiosError(error);

      expect(result).toBe(' API error occurred.');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: ' API error occurred.',
        type: 'danger',
        onClose: null,
      });
    });
  });

  describe('when error.request is present (Network Error)', () => {
    it('redirects to /service-unavailable if not on /login or /service-unavailable', () => {
      window.location.pathname = '/dashboard';
      const error = {
        request: {},
      };

      const result = handleAxiosError(error);

      expect(result).toBe('Network error. Could not connect to the server.');
      expect(window.location.href).toBe('/service-unavailable');
      // show should not be called since we return early
      expect(MessageBoxService.show).not.toHaveBeenCalled();
    });

    it('does not redirect if on /login', () => {
      window.location.pathname = '/login';
      const error = {
        request: {},
      };

      const result = handleAxiosError(error);

      expect(result).toBe('Network error. Could not connect to the server.');
      expect(window.location.href).toBe('');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: 'Network error. Could not connect to the server.',
        type: 'danger',
        onClose: null,
      });
    });

    it('does not redirect if on /service-unavailable', () => {
      window.location.pathname = '/service-unavailable';
      const error = {
        request: {},
      };

      const result = handleAxiosError(error);

      expect(result).toBe('Network error. Could not connect to the server.');
      expect(window.location.href).toBe('');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: 'Network error. Could not connect to the server.',
        type: 'danger',
        onClose: null,
      });
    });

    it('handles exception during location check gracefully', () => {
      // Intentionally cause an error when accessing window.location.pathname
      Object.defineProperty(window, 'location', {
        get: () => { throw new Error('Access denied'); },
        configurable: true
      });

      const error = {
        request: {},
      };

      const result = handleAxiosError(error);

      expect(result).toBe('Network error. Could not connect to the server.');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: 'Network error. Could not connect to the server.',
        type: 'danger',
        onClose: null,
      });
    });
  });

  describe('when no response or request (General Error)', () => {
    it('handles general errors', () => {
      const error = {
        message: 'Something went wrong',
      };

      const result = handleAxiosError(error);

      expect(result).toBe('Error: Something went wrong');
      expect(MessageBoxService.show).toHaveBeenCalledWith({
        message: 'Error: Something went wrong',
        type: 'danger',
        onClose: null,
      });
    });
  });
});
