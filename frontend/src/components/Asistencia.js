import React, { useEffect, useState } from 'react';

function Asistencia() {
  const [fechaSeleccionada, setFechaSeleccionada] = useState('');
  const [studentId, setStudentId] = useState('');
  const [isPresent, setIsPresent] = useState(false);
  const [asistencia, setAsistencia] = useState([]);

  const obtenerDatos = async () => {
    if (fechaSeleccionada === '') {
      console.log('Selecciona una fecha');
      return;
    }

    const data = await fetch(`http://localhost:5003/api/Attendance/history/${fechaSeleccionada}`);
    const response = await data.json();
    setAsistencia(response.data);
  };

  const agregarAsistencia = async () => {
    if (fechaSeleccionada === '' || studentId === '') {
      alert('Completa todos los campos');
      return;
    }

    const fechaActual = new Date().toISOString();

    const data = {
      studentId: parseInt(studentId),
      date: fechaActual,
      isPresent: isPresent,
    };

    const response = await fetch('http://localhost:5003/api/Attendance', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    });

    if (response.ok) {
      alert('Asistencia agregada correctamente');
      obtenerDatos(); // Volver a obtener los datos actualizados después de agregar la asistencia
    } else {
      alert('Error al agregar la asistencia');
    }
  };

  const modificarAsistencia = async (id) => {
    const fechaActual = new Date().toISOString();

    const data = {
      id: id,
      studentId: parseInt(studentId),
      date: fechaActual,
      isPresent: isPresent,
    };

    const response = await fetch(`http://localhost:5003/api/Attendance/${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(data),
    });

    if (response.ok) {
      alert('Asistencia modificada correctamente');
      obtenerDatos(); // Volver a obtener los datos actualizados después de modificar la asistencia
    } else {
      alert('Error al modificar la asistencia');
    }
  };

  const eliminarAsistencia = async (id) => {
    const response = await fetch(`http://localhost:5003/api/Attendance/${id}`, {
      method: 'DELETE',
    });

    if (response.ok) {
      alert('Asistencia eliminada correctamente');
      obtenerDatos(); // Volver a obtener los datos actualizados después de eliminar la asistencia
    } else {
      alert('Error al eliminar la asistencia');
    }
  };

  const consultarAsistencia = async () => {
    if (fechaSeleccionada === '') {
      alert('Selecciona una fecha');
      return;
    }

    obtenerDatos();
  };

  useEffect(() => {
    obtenerDatos();
  }, []);

  return (
    <div>
      <h2 className='text-center'>Listado de asistencia</h2>
      <div className="d-flex gap-3 mb-3">
        <div>
          <label htmlFor='fecha'>Selecciona una fecha:</label>
          <input type='date' id='fecha' value={fechaSeleccionada} onChange={(e) => setFechaSeleccionada(e.target.value)} />
        </div>
  
        <div>
          <label htmlFor='studentId'>Student ID:</label>
          <input type='number' id='studentId' value={studentId} onChange={(e) => setStudentId(e.target.value)} />
        </div>
  
        <div>
          <label htmlFor='isPresent'>Is Present:</label>
          <input
            type='checkbox' id='isPresent' checked={isPresent} onChange={(e) => setIsPresent(!!e.target.checked)}
          />
        </div>
  
        <button className='btn btn-primary' onClick={agregarAsistencia}>
          Agregar Asistencia
        </button>
  
        <button className='btn btn-primary' onClick={consultarAsistencia}>
          Consultar Asistencia
        </button>
      </div>
  
      <table className='table'>
        <thead>
          <tr>
            <th scope='col'>#</th>
            <th scope='col'>Student ID</th>
            <th scope='col'>Date</th>
            <th scope='col'>Presence</th>
            <th scope='col'>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {asistencia.map((item, index) => (
            <tr key={index}>
              <th scope='row'>{index + 1}</th>
              <td>{item.studentId}</td>
              <td>{item.date}</td>
              <td>{item.isPresent ? 'Present' : 'Absent'}</td>
              <td>
                <button className='btn btn-primary' onClick={() => modificarAsistencia(item.id)}>
                  Modificar
                </button>
                <button className='btn btn-danger' onClick={() => eliminarAsistencia(item.id)}>
                  Eliminar
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Asistencia;
