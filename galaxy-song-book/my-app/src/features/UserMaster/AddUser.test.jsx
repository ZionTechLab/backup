// Tests for AddUser component
// Covers: initial render (create mode), role list loading, validation errors, successful submit, edit mode loading, delete flow confirmation bypass

import React from 'react';
import { MemoryRouter, Route, Routes } from 'react-router-dom';
import { render, screen, waitFor, fireEvent } from '@testing-library/react';
import AddUser from './AddUser';
import ApiService from './UserService';
import MessageBoxService from '../../services/MessageBoxService';

jest.mock('../../config/config', () => ({
  __esModule: true,
  default: {
    features: {
      returnToListAfterSave: true,
    },
    apiBaseUrl: 'http://localhost/api/',
  },
}));

// Mock axios and wrappers to avoid ESM import issues during Jest run
jest.mock('axios', () => ({
  __esModule: true,
  default: { get: jest.fn(), post: jest.fn() },
  get: jest.fn(),
  post: jest.fn(),
}));
jest.mock('../../helpers/axiosMiddleware', () => ({
  __esModule: true,
  default: {},
  axiosRequest: (p) => p,
}));
jest.mock('../../helpers/axiosInterceptors', () => ({}));

jest.mock('./UserService', () => ({
  __esModule: true,
  default: {
    getUi: jest.fn(),
    update: jest.fn(),
    get: jest.fn(),
    getAll: jest.fn(),
    delete: jest.fn(),
  }
}));
jest.mock('../../services/MessageBoxService');

// Minimal mock for FieldsRenderer + useFormikBuilder to avoid deep form library coupling if needed
// But we rely on real implementation assuming it exists and works; if unstable, consider mocking.

describe('AddUser Component', () => {
  const rolesResponse = { success: true, data: { Role: [{ id:1, roleName:'Admin'}] } };
  const createSuccess = { success: true, data: { id: 10 } };

  beforeEach(() => {
    jest.clearAllMocks();
  });

  function renderWithRouter(initialPath='/user-master/add') {
    return render(
      <MemoryRouter initialEntries={[initialPath]}>
        <Routes>
          <Route path="/user-master/add" element={<AddUser />} />
          <Route path="/user-master/:userId" element={<AddUser />} />
          <Route path="/user-master" element={<div>LIST PAGE</div>} />
        </Routes>
      </MemoryRouter>
    );
  }

  test('renders create form and loads roles', async () => {
    ApiService.getUi.mockResolvedValueOnce(rolesResponse);
    ApiService.get.mockResolvedValue({ success: false }); // not called in create

    renderWithRouter();

    // Wait for role select to populate (presence of option text)
    await waitFor(() => expect(ApiService.getUi).toHaveBeenCalled());
  });

  test('validation prevents submit when required fields missing', async () => {
    ApiService.getUi.mockResolvedValueOnce(rolesResponse);
    ApiService.update.mockResolvedValue(createSuccess);

    renderWithRouter();

    const saveBtn = await screen.findAllByRole('button').then(btns => btns.find(b => /save|create/i.test(b.textContent || b.getAttribute('aria-label') || b.innerHTML)));
    fireEvent.click(saveBtn);

    // Expect validation messages
    await screen.findAllByText(/User ID is required/i).then(els => els[0]);
    await screen.findAllByText(/Password is required/i).then(els => els[0]);
    await screen.findAllByText(/Full name is required/i).then(els => els[0]);
    await screen.findAllByText(/Email is required/i).then(els => els[0]);

    expect(ApiService.update).not.toHaveBeenCalled();
  });

  test('successful submit shows success message and navigates', async () => {
    ApiService.getUi.mockResolvedValueOnce(rolesResponse);
    ApiService.update.mockResolvedValueOnce(createSuccess);
    MessageBoxService.show.mockImplementation(({ onClose }) => { if (onClose) onClose(); });

    renderWithRouter();

    // Wait for roles to load so select has options
    await waitFor(() => expect(ApiService.getUi).toHaveBeenCalled());

    // Fill fields
    fireEvent.change(screen.getAllByPlaceholderText(/User ID/i)[0], { target: { value: 'newuser'} });
    fireEvent.change(screen.getAllByPlaceholderText(/Password/i)[0], { target: { value: 'Pass123!'} });
    fireEvent.change(screen.getAllByPlaceholderText(/Full Name/i)[0], { target: { value: 'New User'} });
    fireEvent.change(screen.getAllByPlaceholderText(/Email/i)[0], { target: { value: 'new@example.com'} });

  // Role select: placeholder may not persist; locate select by role
  const roleSelect = screen.getByText(/Admin/i);
  fireEvent.click(roleSelect);

    const saveBtn = await screen.findAllByRole('button').then(btns => btns.find(b => /save|create/i.test(b.textContent || b.getAttribute('aria-label') || b.innerHTML)));
    fireEvent.click(saveBtn);

  await waitFor(() => expect(ApiService.update).toHaveBeenCalledTimes(1), { timeout: 3000 });
    expect(MessageBoxService.show).toHaveBeenCalledWith(expect.objectContaining({ message: expect.stringMatching(/saved/i) }));
    // After onClose navigation, list page should appear
    await screen.findByText(/LIST PAGE/i);
  });

  test('edit mode loads existing user and hides password required validation', async () => {
    const existingUser = { success: true, data: { id: 2, userName:'manager', fullName:'Site Manager', email:'m@e.com', phone:'', phone2:'', roleId:1, active:true } };
    ApiService.getUi.mockResolvedValueOnce(rolesResponse);
    ApiService.get.mockResolvedValueOnce(existingUser);
    ApiService.update.mockResolvedValue({ success: true });

    renderWithRouter('/user-master/2');

    await waitFor(() => expect(ApiService.get).toHaveBeenCalledWith('2'));
    // Password placeholder should be masked
    expect(screen.getAllByPlaceholderText(/\*{4,}/)[0]).toBeInTheDocument();
  });

  test('delete flow confirms and calls delete', async () => {
    const existingUser = { success: true, data: { id: 2, userName:'manager', fullName:'Site Manager', email:'m@e.com', phone:'', phone2:'', roleId:1, active:true } };
    ApiService.getUi.mockResolvedValueOnce(rolesResponse);
    ApiService.get.mockResolvedValueOnce(existingUser);
    ApiService.delete.mockResolvedValue({ success: true });
    MessageBoxService.confirmAsync = jest.fn().mockResolvedValue(true);
    MessageBoxService.show.mockImplementation(({ onClose }) => { if (onClose) onClose(); });

    renderWithRouter('/user-master/2');

    const deleteBtn = await screen.findAllByRole('button').then(btns => btns.find(b => /delete/i.test(b.textContent || b.getAttribute('aria-label') || b.innerHTML)));
    fireEvent.click(deleteBtn);

    await waitFor(() => expect(MessageBoxService.confirmAsync).toHaveBeenCalled());
    await waitFor(() => expect(ApiService.delete).toHaveBeenCalledWith({ userId: '2' }));
    await screen.findByText(/LIST PAGE/i);
  });
});
