import { render, screen } from '@testing-library/react';
import { Provider } from 'react-redux';
import { HashRouter } from 'react-router-dom';
import store from './store';
import App from './App';

test('renders login page by default when not authenticated', async () => {
  render(
    <HashRouter>
      <Provider store={store}>
        <App />
      </Provider>
    </HashRouter>
  );
  // Look for login heading
  expect(await screen.findByText(/welcome back/i)).toBeInTheDocument();
  expect(screen.getByRole('button', { name: /sign in/i })).toBeInTheDocument();
});
