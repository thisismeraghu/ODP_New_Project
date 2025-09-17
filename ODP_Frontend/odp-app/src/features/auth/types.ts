export interface LoginPayload {
  username: string;
  password: string;
}

export interface User {
  id: string;
  name: string;
  email: string;
}

export interface LoginResponse {
  username: string;
  token: string;
}
