import axios from 'axios';

export const registerUser = async (userData) => {
  try {
    const response = await axios.post('https://localhost:7212/register', userData, {
      withCredentials: true, // Ensure cookies are sent
    });
  
    // Optional: handle token after registration if needed
    const token = response.data.token; 
    return token;
  } catch (error) {
    console.error('Registration failed:', error);
    throw error; // Optionally handle error in form
  }
};
