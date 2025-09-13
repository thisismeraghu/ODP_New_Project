// src/features/auth/authAPI.ts
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
