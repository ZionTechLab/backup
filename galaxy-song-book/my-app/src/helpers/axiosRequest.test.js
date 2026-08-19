import { axiosRequest } from './axiosRequest';
import LoadingSpinnerService from '../services/LoadingSpinnerService';
import { handleAxiosError } from './axiosErrorHandler';

jest.mock('../services/LoadingSpinnerService', () => ({
  show: jest.fn(),
  hide: jest.fn(),
}));

jest.mock('./axiosErrorHandler', () => ({
  handleAxiosError: jest.fn(),
}));

describe('axiosRequest', () => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  it('should handle a successful request with default options', async () => {
    const mockData = { data: 'some-data' };
    const requestPromise = Promise.resolve(mockData);

    const result = await axiosRequest(requestPromise);

    expect(LoadingSpinnerService.show).toHaveBeenCalledWith('Loading...');
    expect(result).toEqual({ data: 'some-data', error: null, success: true });
    expect(LoadingSpinnerService.hide).toHaveBeenCalled();
  });

  it('should handle a successful request with showSpinner: false', async () => {
    const mockData = { data: 'some-data' };
    const requestPromise = Promise.resolve(mockData);

    const result = await axiosRequest(requestPromise, { showSpinner: false });

    expect(LoadingSpinnerService.show).not.toHaveBeenCalled();
    expect(result).toEqual({ data: 'some-data', error: null, success: true });
    expect(LoadingSpinnerService.hide).not.toHaveBeenCalled();
  });

  it('should handle a failed request with default options', async () => {
    const mockError = new Error('Network error');
    const requestPromise = Promise.reject(mockError);
    handleAxiosError.mockReturnValue('Handled Error Message');

    const result = await axiosRequest(requestPromise);

    expect(LoadingSpinnerService.show).toHaveBeenCalledWith('Loading...');
    expect(handleAxiosError).toHaveBeenCalledWith(mockError);
    expect(result).toEqual({ data: null, error: 'Handled Error Message', success: false });
    expect(LoadingSpinnerService.hide).toHaveBeenCalled();
  });

  it('should handle a failed request with showSpinner: false', async () => {
    const mockError = new Error('Network error');
    const requestPromise = Promise.reject(mockError);
    handleAxiosError.mockReturnValue('Handled Error Message');

    const result = await axiosRequest(requestPromise, { showSpinner: false });

    expect(LoadingSpinnerService.show).not.toHaveBeenCalled();
    expect(handleAxiosError).toHaveBeenCalledWith(mockError);
    expect(result).toEqual({ data: null, error: 'Handled Error Message', success: false });
    expect(LoadingSpinnerService.hide).not.toHaveBeenCalled();
  });

  it('should use custom message for spinner', async () => {
    const mockData = { data: 'some-data' };
    const requestPromise = Promise.resolve(mockData);

    const result = await axiosRequest(requestPromise, { message: 'Custom loading...' });

    expect(LoadingSpinnerService.show).toHaveBeenCalledWith('Custom loading...');
    expect(result).toEqual({ data: 'some-data', error: null, success: true });
    expect(LoadingSpinnerService.hide).toHaveBeenCalled();
  });
});
