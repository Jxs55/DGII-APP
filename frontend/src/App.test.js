import { render, screen } from '@testing-library/react';
import App from './App';

jest.mock('./api/dgiiApi', () => ({
  getContribuyentes: jest.fn(() => Promise.resolve({ data: [] })),
  getComprobantes: jest.fn(() => Promise.resolve({ data: [] })),
  getTotalItbis: jest.fn(() => Promise.resolve({ data: { totalItbis: 0 } })),
}));

test('renders DGII main screen', () => {
  render(<App />);

  expect(screen.getByRole('heading', { name: /consulta dgii/i })).toBeInTheDocument();
  expect(screen.getByLabelText(/contribuyente/i)).toBeInTheDocument();
});
