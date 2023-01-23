import { ROLES } from "../../auth/roles";
import { ILoginUser } from "../interfaces/common/ILoginUser";
import { Script } from "../model/script";


export function isAdminOrScriptOwner(script: Script,currentUser: ILoginUser)
{
  const userRoles = currentUser.role;
  const isAdmin = userRoles.includes(ROLES.ADMIN);

  if(script.createdBy === currentUser.id || isAdmin)
    return true;

  return false;
}
