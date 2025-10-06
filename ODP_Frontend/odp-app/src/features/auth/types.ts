export interface LoginPayload {
  username: string;
  password: string;
}

export interface LoginResponse {
  userID: number,
  firstName: string,
  lastName: string,
  roleType: string,
  orgID: number,                                                                                                                    
  orgName: string,                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
  token : string
}

export interface LoginResponseDTO {
  userID: number,
  firstName: string,
  lastName: string,
  roleType: string,
  orgID: number,
  orgName: string,
  token : string
}