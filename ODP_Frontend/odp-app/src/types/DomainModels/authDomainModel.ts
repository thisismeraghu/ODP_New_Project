

export class AuthDomainModel{
  userId: number;
  firstName: string;
  lastName: string;
  roleType: string;
  orgId: number;
  orgName: string;
  token: string;

  constructor(
    userId: number,
    firstName: string,
    lastName: string,
    roleType: string,
    orgId: number,
    orgName: string,
    token: string
  ) {
    this.userId = userId;
    this.firstName = firstName;
    this.lastName = lastName;
    this.roleType = roleType;
    this.orgId = orgId;
    this.orgName = orgName;
    this.token = token;
  };
}