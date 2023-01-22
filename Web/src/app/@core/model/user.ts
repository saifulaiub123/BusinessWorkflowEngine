import { IUser } from "../interfaces/common/users";
import { UserRole } from "./user-role";

export class User implements  IUser {
  id?: number;
  firstName?: string;
  lastName?: string;
  email?: string;
  phoneNumber?: string;
  userRoles? : UserRole[];
}
