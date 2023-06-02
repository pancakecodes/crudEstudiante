import React from 'react';
import { Routes, Route, Link} from 'react-router-dom';
import Estudiantes from './components/Estudiantes';
import Calificaciones from './components/Calificaciones';
import Asistencia from './components/Asistencia';
import Inicio from './components/Inicio';
import './App.css';

function App() {
  return (
    <div className="App">
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
        <div className="container">
          <a className="navbar-brand" href="/">Gestion Estudiante</a>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <Link className="nav-link active" aria-current="page" to="/">Inicio</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/estudiantes">Estudiantes</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/asistencia">Asistencia</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/calificaciones">Calificaciones</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <div className='App-body'>
      <Routes>
        <Route path="/" element={<Inicio/>} />
        <Route path="calificaciones"element={<Calificaciones/>} />
        <Route path="asistencia" element={<Asistencia/>} />
        <Route path="estudiantes" element={<Estudiantes/>} />
      </Routes>
      </div>
      <div className='App-footer'>
  <a href="https://github.com/pancakecodes" target="_blank" rel="noopener noreferrer">
    <i className="fab fa-github"></i>
  </a>
  <a href="https://www.linkedin.com/in/sahernandezg/" target="_blank" rel="noopener noreferrer">
    <i className="fab fa-linkedin"></i>
  </a>
</div>

    </div>

  );
}

export default App;
