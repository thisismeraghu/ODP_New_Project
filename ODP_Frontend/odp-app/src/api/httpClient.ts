// src/api/httpClient.ts
import axios from 'axios';

const httpClient = axios.create({
  baseURL: 'https://localhost:7011/',//import.meta.env.VITE_API_BASE_URL, // Vite env variable e.g., http://localhost:4000/api
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 10000,
});

// Add interceptors for auth token, logging, etc if necessary
httpClient.interceptors.response.use(
  response => response,
  error => {
    // Unified error handling
    return Promise.reject(error?.response?.data || error.message);
  }
);

export default httpClient;
