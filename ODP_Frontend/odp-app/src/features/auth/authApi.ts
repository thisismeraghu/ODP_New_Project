// // src/features/auth/authAPI.ts
import { apiRequest } from '../../api/request';
import type { LoginRequestDTO } from '../../types/DTOs/loginRequestDTO';
import type { LoginResponseDTO } from '../../types/DTOs/loginResponseDTO';

export const loginUser = async (payload: LoginRequestDTO): Promise<LoginResponseDTO> => {
  return apiRequest<LoginResponseDTO, LoginRequestDTO>({
    path: '/api/login',   // replace with your actual login endpoint path
    method: 'POST',
    data: payload,
  });
};

