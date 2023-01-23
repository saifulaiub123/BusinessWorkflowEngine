import { ROLES } from "../../auth/roles";
import { IUser } from "../interfaces/common/users";
import { Script } from "../model/script";


export function isAdminOrScriptOwner(script: Script,currentUser: IUser)
{
  // const userRoles = currentUser.userRoles;
  // const isAdmin = userRoles.includes(ROLES.ADMIN);

  // if(isAdmin) return true;
  if(script.createdBy === currentUser.id) return true;

  return false;
}
