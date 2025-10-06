import type { AuthDomainModel } from "../../types/DomainModels/authDomainModel";
import type { UserDisplayModel } from "../../types/UiModels/UserDisplayModel";



export function mapAuthDomainToLoginDisplay(dto:AuthDomainModel): UserDisplayModel {
  return {
    userId: dto.userId,
    firstName: dto.firstName,
    lastName: dto.lastName,
    roleType: dto.roleType,
    orgId: dto.orgId,
    orgName: dto.orgName
  };
}

