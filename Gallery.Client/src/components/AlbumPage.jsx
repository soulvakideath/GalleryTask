import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

const API_BASE_URL = 'https://localhost:7212';
const TOKEN_KEY = 'secretCookie';

const AlbumPage = () => {
  const navigate = useNavigate();
  const [albums, setAlbums] = useState([]);
  const [title, setTitle] = useState('');
  const [albumId, setAlbumId] = useState('');
  const [isEditing, setIsEditing] = useState(false);

  useEffect(() => {
    getAlbums();
  }, []);

  const getAlbums = async () => {
    try {
      const token = getCookie(TOKEN_KEY).replace(/"/g, ''); 
      const response = await fetch(`${API_BASE_URL}/album`, {
        method: 'GET',
        headers: {
          Authorization: `Bearer ${token}`,
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        credentials: 'include',
      });

      if (response.ok) {
        const data = await response.json();
        setAlbums(data);
      } else {
        console.error('Error fetching albums');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const createAlbum = async () => {
    try {
      const token = getCookie(TOKEN_KEY).replace(/"/g, ''); // Get token from cookie and remove double quotes
      const response = await fetch(`${API_BASE_URL}/album`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({ title }),
        credentials: 'include',
      });

      if (response.ok) {
        getAlbums();
        setTitle('');
      } else {
        console.error('Error creating album');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const updateAlbum = async () => {
    try {
      const token = getCookie(TOKEN_KEY).replace(/"/g, ''); // Get token from cookie and remove double quotes
      const response = await fetch(`${API_BASE_URL}/album/${albumId}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({ title }),
        credentials: 'include',
      });

      if (response.ok) {
        getAlbums();
        setIsEditing(false);
        setTitle('');
      } else {
        console.error('Error updating album');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const deleteAlbum = async (id) => {
    try {
      const token = getCookie(TOKEN_KEY).replace(/"/g, ''); // Get token from cookie and remove double quotes
      const response = await fetch(`${API_BASE_URL}/album/${id}`, {
        method: 'DELETE',
        headers: {
          Authorization: `Bearer ${token}`,
        },
        credentials: 'include',
      });

      if (response.ok) {
        getAlbums();
      } else {
        console.error('Error deleting album');
      }
    } catch (error) {
      console.error(error);
    }
  };

  const getCookie = (cname) => {
    let name = cname + '=';
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
      let c = ca[i];
      while (c.charAt(0) === ' ') {
        c = c.substring(1);
      }
      if (c.indexOf(name) === 0) {
        return c.substring(name.length, c.length);
      }
    }
    return '';
  };

  const handleEdit = (album) => {
    setIsEditing(true);
    setAlbumId(album.id);
    setTitle(album.title);
  };

  const handleDelete = (id) => {
    deleteAlbum(id);
  };

  return (
    <div>
      <h1>Albums</h1>
      <ul>
        {albums.map((album) => (
          <li key={album.id}>
            {album.title}
            <button onClick={() => handleEdit(album)}>Edit</button>
            <button onClick={() => handleDelete(album.id)}>Delete</button>
          </li>
        ))}
      </ul>
      {isEditing ? (
        <div>
          <input
            type="text"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          />
          <button onClick={updateAlbum}>Update</button>
        </div>
      ) : (
        <div>
          <input
            type="text"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          />
          <button onClick={createAlbum}>Create</button>
        </div>
      )}
    </div>
  );
};

export default AlbumPage;