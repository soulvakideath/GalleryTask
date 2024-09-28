// App.jsx
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import AlbumCreator from './components/AlbumPage';
import ImageCarousel from './components/ImageCarousel';
import LoginForm from './components/LoginForm';
import RegistrationForm from './components/RegistrationForm';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/login" element={<LoginForm />} />
        <Route path="/register" element={<RegistrationForm />} />
        <Route path="/album" element={<AlbumCreator />} />
        <Route path="/album/:albumId" element={<ImageCarousel />} />
      </Routes>
    </Router>
  );
}

export default App;