import React, { useState, useEffect } from 'react';

function Estudiantes() {
  const [estudiantes, setEstudiantes] = useState([]);
  const [filteredEstudiantes, setFilteredEstudiantes] = useState([]);
  const [searchText, setSearchText] = useState('');
  const [newStudentData, setNewStudentData] = useState({
    firstName: '',
    lastName: ''
  });
  const [selectedStudent, setSelectedStudent] = useState(null);

  const obtenerDatos = async () => {
    const data = await fetch('http://localhost:5003/api/Student/GetAll');
    const estudiantes = await data.json();
    setEstudiantes(estudiantes.data);
    setFilteredEstudiantes(estudiantes.data);
  };

  useEffect(() => {
    obtenerDatos();
  }, []);

  const handleSearch = () => {
    if (searchText.trim() !== '') {
      const filteredEstudiantes = estudiantes.filter(
        estudiante => estudiante.firstName.toLowerCase().includes(searchText.toLowerCase())
      );
      setFilteredEstudiantes(filteredEstudiantes);
    } else {
      setFilteredEstudiantes(estudiantes);
    }
  };

  const handleAddStudent = async () => {
    const response = await fetch('http://localhost:5003/api/Student', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(newStudentData)
    });
    const data = await response.json();
    setEstudiantes(data.data);
    setFilteredEstudiantes(data.data);
    setNewStudentData({
      firstName: '',
      lastName: ''
    });
  };

  const handleDeleteStudent = async (id) => {
    const response = await fetch(`http://localhost:5003/api/Student/${id}`, {
      method: 'DELETE'
    });
    const data = await response.json();
    setEstudiantes(data.data);
    setFilteredEstudiantes(data.data);
  };

  const handleEditStudent = (student) => {
    setSelectedStudent(student);
    setNewStudentData({
      id: student.id,
      firstName: student.firstName,
      lastName: student.lastName
    });
  };

  const handleUpdateStudent = async () => {
    const response = await fetch('http://localhost:5003/api/Student', {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(newStudentData)
    });
    const data = await response.json();
    setEstudiantes(data.data);
    setFilteredEstudiantes(data.data);
    setSelectedStudent(null);
    setNewStudentData({
      firstName: '',
      lastName: ''
    });
  };

  return (
    <div>
      <h1 className='text-center'>Listado de estudiantes</h1>
      <div className='search'>
        <input
          type="text"
          placeholder="Nombre del estudiante"
          value={searchText}
          onChange={event => setSearchText(event.target.value)}
        />
        <button className="btn btn-success" type="button" onClick={handleSearch}>
          Buscar
        </button>
      </div>
      <ol>
        {filteredEstudiantes.map(estudiante => (
          <li  key={estudiante.id}>
            {estudiante.firstName} {estudiante.lastName}
            <button className="btn btn-primary" onClick={() => handleEditStudent(estudiante)}>Editar</button>
            <button className="btn btn-danger" onClick={() => handleDeleteStudent(estudiante.id)}>Eliminar</button>
          </li>
        ))}
      </ol>
      <div className="add-student">
        <h1>Agregar estudiante</h1>
        <input
          type="text"
          placeholder="Nombre"
          value={newStudentData.firstName}
          onChange={event =>
            setNewStudentData({ ...newStudentData, firstName: event.target.value })
          }
        />
        <input
          type="text"
          placeholder="Apellido"
          value={newStudentData.lastName}
          onChange={event =>
            setNewStudentData({ ...newStudentData, lastName: event.target.value })
          }
        />
        <button className="btn btn-primary" onClick={handleAddStudent}>
          Agregar
        </button>
      </div>
      {selectedStudent && (
        <div className="edit-student">
          <h2>Editar estudiante</h2>
          <input
            type="text"
            placeholder="Nombre"
            value={newStudentData.firstName}
            onChange={event =>
              setNewStudentData({ ...newStudentData, firstName: event.target.value })
            }
          />
          <input
            type="text"
            placeholder="Apellido"
            value={newStudentData.lastName}
            onChange={event =>
              setNewStudentData({ ...newStudentData, lastName: event.target.value })
            }
          />
          <button className="btn btn-primary" onClick={handleUpdateStudent}>
            Actualizar
          </button>
        </div>
      )}
    </div>
  );
}

export default Estudiantes;
