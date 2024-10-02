import axios from 'axios';

const API_URL = 'https://localhost:7212';

export const loginUser = async (email, password) => {
  try {
    const response = await axios.post(`${API_URL}/login`, { email, password });
    let token = response.data;
    
    token = token.replace(/^"|"$/g, '');
    
    document.cookie = `secretCookie=${token}; path=/; secure; sameSite=lax;`;
    
    return token;
  } catch (error) {
    console.error(error);
    throw error;
  }
};
