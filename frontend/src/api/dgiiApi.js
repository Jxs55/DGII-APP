import axios from 'axios';

const api = axios.create({ baseURL: 'http://localhost:5000/api' });

export const getContribuyentes = () => api.get('/contribuyentes');
export const getComprobantes = (rnc) =>
  api.get(`/comprobantesfiscales/contribuyente/${rnc}`);
export const getTotalItbis = (rnc) =>
  api.get(`/comprobantesfiscales/contribuyente/${rnc}/total-itbis`);
