import React, { useEffect, useState } from 'react';

function Calificaciones() {
  const [calificaciones, setCalificaciones] = useState([]);
  const [nuevaCalificacion, setNuevaCalificacion] = useState({
    studentId: 0,
    subject: '',
    totalGrade: 0,
    letterGrade: ''
  });

  const obtenerDatos = async () => {
    const data = await fetch('http://localhost:5003/api/Grade/GetAll');
    const calificaciones = await data.json();
    setCalificaciones(calificaciones.data);
    console.log(calificaciones);
  };

  useEffect(() => {
    obtenerDatos();
  }, [calificaciones]);

  const enviarCalificacion = async () => {
    const { totalGrade } = nuevaCalificacion;
    let letterGrade = '';
    if (totalGrade >= 90 && totalGrade <= 100) {
      letterGrade = 'A';
    } else if (totalGrade >= 80 && totalGrade <= 89) {
      letterGrade = 'B';
    } else if (totalGrade >= 70 && totalGrade <= 79) {
      letterGrade = 'C';
    } else {
      letterGrade = 'F';
    }
    setNuevaCalificacion({
      ...nuevaCalificacion,
      letterGrade: letterGrade
    });

    const response = await fetch('http://localhost:5003/api/Grade/', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(nuevaCalificacion)
    });

    if (response.ok) {
      alert('Calificación agregada correctamente');
      obtenerDatos(); // Volver a obtener los datos actualizados después de agregar la calificación
    } else {
      alert('Error al agregar la calificación');
    }
  };

  const modificarCalificacion = async (id) => {
    const { totalGrade } = nuevaCalificacion;
    let letterGrade = '';
    if (totalGrade >= 90 && totalGrade <= 100) {
      letterGrade = 'A';
    } else if (totalGrade >= 80 && totalGrade <= 89) {
      letterGrade = 'B';
    } else if (totalGrade >= 70 && totalGrade <= 79) {
      letterGrade = 'C';
    } else {
      letterGrade = 'F';
    }
    setNuevaCalificacion({
      ...nuevaCalificacion,
      letterGrade: letterGrade
    });

    const response = await fetch(`http://localhost:5003/api/Grade/${id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(nuevaCalificacion)
    });

    if (response.ok) {
      alert('Calificación modificada correctamente');
      obtenerDatos(); // Volver a obtener los datos actualizados después de modificar la calificación
    } else {
      alert('Error al modificar la calificación');
    }
  };

  const eliminarCalificacion = async (id) => {
    const response = await fetch(`http://localhost:5003/api/Grade/${id}`, {
      method: 'DELETE'
    });

    if (response.ok) {
      alert('Calificación eliminada correctamente');
      obtenerDatos(); // Volver a obtener los datos actualizados después de eliminar la calificación
    } else {
      alert('Error al eliminar la calificación');
    }
  };

  const handleChange = (e) => {
    setNuevaCalificacion({
      ...nuevaCalificacion,
      [e.target.name]: e.target.value
    });
  };

  return (
    <div>
      <h1>Calificaciones</h1>
      <div className='d-flex gap-3'>
        <input
          type='text'
          placeholder='Student ID'
          name='studentId'
          value={nuevaCalificacion.studentId}
          onChange={handleChange}
        />
        <select
          className='form-select'
          style={{ width: 'auto' }}
          name='subject'
          value={nuevaCalificacion.subject}
          onChange={handleChange}
        >
          <option value=''>Seleccionar materia</option>
          <option value='Lengua Española'>Lengua Española</option>
          <option value='Matemáticas'>Matemáticas</option>
          <option value='Ciencias sociales'>Ciencias sociales</option>
          <option value='Ciencias naturales'>Ciencias naturales</option>
        </select>
        <input
          type='number'
          placeholder='Total Grade'
          name='totalGrade'
          value={nuevaCalificacion.totalGrade}
          onChange={handleChange}
        />
        <input
          type='text'
          placeholder='Letter Grade'
          name='letterGrade'
          value={nuevaCalificacion.letterGrade}
          onChange={handleChange}
          disabled
        />
        <button className='btn btn-success' type='button' onClick={enviarCalificacion}>
          Enviar Calificación
        </button>
      </div>
      <hr />
      <h1>Calificaciones registradas:</h1>
      <table className='table'>
        <thead>
          <tr>
            <th scope='col'>#</th>
            <th scope='col'>Student ID</th>
            <th scope='col'>Subject</th>
            <th scope='col'>Total Grade</th>
            <th scope='col'>Letter Grade</th>
            <th scope='col'>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {calificaciones.map((calificacion, index) => (
            <tr key={index}>
              <th scope='row'>{index + 1}</th>
              <td>{calificacion.studentId}</td>
              <td>{calificacion.subject}</td>
              <td>{calificacion.totalGrade}</td>
              <td>{calificacion.letterGrade}</td>
              <td>
                <button className='btn btn-primary' onClick={() => modificarCalificacion(calificacion.id)}>
                  Modificar
                </button>
                <button className='btn btn-danger' onClick={() => eliminarCalificacion(calificacion.id)}>
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

export default Calificaciones;
