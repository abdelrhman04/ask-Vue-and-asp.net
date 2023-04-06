import axios from 'axios';

export const instance = axios.create({
  baseURL: 'https://localhost:7132/api/',
  headers: {
    'Authorization': `Bearer ${localStorage.getItem('token')}`,
  }
})
 
export const instanceproduct = axios.create({
  baseURL: 'https://localhost:7132/api/',
  headers: {
    'Authorization':`Bearer ${localStorage.getItem('token')}`,
    'Content-Type': 'multipart/form-data'
  }
});
  
