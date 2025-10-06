export interface LoginResponseDTO {
  userID: number,
  firstName: string,
  lastName: string,
  roleType: string,
  orgID: number,
  orgName: string,
  token : string
}