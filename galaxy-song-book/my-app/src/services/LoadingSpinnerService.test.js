import LoadingSpinnerService from './LoadingSpinnerService';

describe('LoadingSpinnerService', () => {
    beforeEach(() => {
        // Reset the service before each test
        LoadingSpinnerService.unregister();
    });

    test('should not throw when show is called and no functions are registered', () => {
        expect(() => LoadingSpinnerService.show('message')).not.toThrow();
    });

    test('should not throw when hide is called and no functions are registered', () => {
        expect(() => LoadingSpinnerService.hide()).not.toThrow();
    });

    test('should call the registered show function with the provided message', () => {
        const mockShow = jest.fn();
        const mockHide = jest.fn();

        LoadingSpinnerService.register(mockShow, mockHide);
        LoadingSpinnerService.show('loading...');

        expect(mockShow).toHaveBeenCalledTimes(1);
        expect(mockShow).toHaveBeenCalledWith('loading...');
        expect(mockHide).not.toHaveBeenCalled();
    });

    test('should call the registered hide function', () => {
        const mockShow = jest.fn();
        const mockHide = jest.fn();

        LoadingSpinnerService.register(mockShow, mockHide);
        LoadingSpinnerService.hide();

        expect(mockHide).toHaveBeenCalledTimes(1);
        expect(mockShow).not.toHaveBeenCalled();
    });

    test('should not call functions after unregister is called', () => {
        const mockShow = jest.fn();
        const mockHide = jest.fn();

        LoadingSpinnerService.register(mockShow, mockHide);
        LoadingSpinnerService.unregister();

        LoadingSpinnerService.show('test');
        LoadingSpinnerService.hide();

        expect(mockShow).not.toHaveBeenCalled();
        expect(mockHide).not.toHaveBeenCalled();
    });
});
