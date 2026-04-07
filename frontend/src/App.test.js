import { render, screen, waitFor } from '@testing-library/react';
import App from './App';

jest.mock('./api/dgiiApi', () => ({
  getContribuyentes: jest.fn(() => Promise.resolve({ data: [] })),
  getComprobantes: jest.fn(() => Promise.resolve({ data: [] })),
  getTotalItbis: jest.fn(() => Promise.resolve({ data: { totalItbis: 0 } })),
}));

test('renders DGII main screen', async () => {
  render(<App />);

  expect(screen.getByRole('heading', { name: /consulta dgii/i })).toBeInTheDocument();

  await waitFor(() => {
    expect(screen.getByLabelText(/contribuyente/i)).not.toBeDisabled();
  });
});
