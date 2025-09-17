// // src/features/auth/authAPI.ts
import { apiRequest } from '../../api/request';
import type { LoginPayload } from '../../models/auth/request';
import type { LoginResponse } from '../../models/auth/response';

export const loginUser = async (payload: LoginPayload): Promise<LoginResponse> => {
  return apiRequest<LoginResponse, LoginPayload>({
    path: '/api/login',   // replace with your actual login endpoint path
    method: 'POST',
    data: payload,
  });
};

// import axios from 'axios';
// import type { LoginPayload, LoginResponse } from './types';

// // Create an axios instance if needed, or use directly
// const API_URL = 'https://yourapi.com/api'; // replace with your API base URL

// export const loginUser = async (payload: LoginPayload): Promise<LoginResponse> => {
//   const response = await axios.post<LoginResponse>(`${API_URL}/auth/login`, payload);
//   return response.data;
// };
