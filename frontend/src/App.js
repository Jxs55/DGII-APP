import { useEffect, useState } from 'react';
import { getComprobantes, getContribuyentes, getTotalItbis } from './api/dgiiApi';
import './App.css';

function App() {
  const [contribuyentes, setContribuyentes] = useState([]);
  const [selectedRnc, setSelectedRnc] = useState('');
  const [comprobantes, setComprobantes] = useState([]);
  const [totalItbis, setTotalItbis] = useState(0);
  const [loadingContribuyentes, setLoadingContribuyentes] = useState(true);
  const [loadingDetalle, setLoadingDetalle] = useState(false);
  const [error, setError] = useState('');

  useEffect(() => {
    const loadContribuyentes = async () => {
      try {
        const response = await getContribuyentes();
        setContribuyentes(response.data);
      } catch {
        setError('No se pudieron cargar los contribuyentes.');
      } finally {
        setLoadingContribuyentes(false);
      }
    };

    loadContribuyentes();
  }, []);

  useEffect(() => {
    const loadDetalle = async () => {
      if (!selectedRnc) {
        setComprobantes([]);
        setTotalItbis(0);
        return;
      }

      setLoadingDetalle(true);
      try {
        const [comprobantesResponse, totalResponse] = await Promise.all([
          getComprobantes(selectedRnc),
          getTotalItbis(selectedRnc),
        ]);

        setComprobantes(comprobantesResponse.data);
        setTotalItbis(totalResponse.data.totalItbis || 0);
      } catch {
        setError('No se pudo cargar el detalle del contribuyente seleccionado.');
      } finally {
        setLoadingDetalle(false);
      }
    };

    loadDetalle();
  }, [selectedRnc]);

  return (
    <main className="container">
      <h1>Consulta DGII</h1>

      {error && <p className="error">{error}</p>}

      <section className="card">
        <label htmlFor="contribuyente">Contribuyente</label>
        <select
          id="contribuyente"
          value={selectedRnc}
          onChange={(e) => {
            setError('');
            setSelectedRnc(e.target.value);
          }}
          disabled={loadingContribuyentes}
        >
          <option value="">Seleccione un contribuyente</option>
          {contribuyentes.map((contribuyente) => (
            <option key={contribuyente.rncCedula} value={contribuyente.rncCedula}>
              {contribuyente.nombre} ({contribuyente.rncCedula})
            </option>
          ))}
        </select>
      </section>

      <section className="card">
        <h2>Comprobantes fiscales</h2>

        {loadingDetalle && <p>Cargando detalle...</p>}

        {!loadingDetalle && comprobantes.length === 0 && selectedRnc && (
          <p>No hay comprobantes para este contribuyente.</p>
        )}

        {comprobantes.length > 0 && (
          <>
            <div className="table-wrapper">
              <table>
                <thead>
                  <tr>
                    <th>RNC/Cedula</th>
                    <th>NCF</th>
                    <th>Monto</th>
                    <th>ITBIS 18%</th>
                  </tr>
                </thead>
                <tbody>
                  {comprobantes.map((comprobante) => (
                    <tr key={`${comprobante.rncCedula}-${comprobante.ncf}`}>
                      <td>{comprobante.rncCedula}</td>
                      <td>{comprobante.ncf}</td>
                      <td>
                        {Number(comprobante.monto).toLocaleString('es-DO', {
                          minimumFractionDigits: 2,
                        })}
                      </td>
                      <td>
                        {Number(comprobante.itbis18).toLocaleString('es-DO', {
                          minimumFractionDigits: 2,
                        })}
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>

            <p className="total-itbis">
              Total ITBIS:{' '}
              <strong>
                {totalItbis.toLocaleString('es-DO', { minimumFractionDigits: 2 })}
              </strong>
            </p>
          </>
        )}
      </section>
    </main>
  );
}

export default App;
