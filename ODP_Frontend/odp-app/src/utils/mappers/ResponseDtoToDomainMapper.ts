

import type { LoginResponseDTO } from "../../features/auth/types";
import type { AuthDomainModel } from "../../types/DomainModels/authDomainModel";


export function mapLoginResponseDtoToAuthDomainModel(dto: LoginResponseDTO): AuthDomainModel {
  return {
    userId: dto.userID,
    firstName: dto.firstName,
    lastName: dto.lastName,
    roleType: dto.roleType,
    orgId: dto.orgID,
    orgName: dto.orgName,
    token: dto.token,
  };
}

