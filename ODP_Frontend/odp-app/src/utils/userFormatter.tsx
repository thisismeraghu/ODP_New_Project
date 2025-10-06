
import type { UserDisplayModel } from "../types/UiModels/UserDisplayModel";

/**
 * Formats user info as "FirstName (Role)"
 * @param {Object} user - The logged-in user object
 * @param {string} user.firstName
 * @param {string} user.role
 * @returns {string}
 */
export function GetFormatedUserInfo(user: UserDisplayModel | null): string {
  if (!user || !user.firstName || !user.roleType || !user.orgName) return "";
  const capitalize = (str: string) =>
    str.charAt(0).toUpperCase() + str.slice(1);
  return `${user.orgName} ${capitalize(user.firstName)} (${capitalize(user.roleType)})`;
}
