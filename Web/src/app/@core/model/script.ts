import { ScriptUserPermission } from "./script-user-permission";

export class Script {
  id?: number;
  name?: string;
  destinationServerId?: string;
  destinationServerName?: string;
  content?: string;
  sendTo?: string;
  createdBy?: number;
  dateCreated?: string;
  lastUpdated?: string;
  scriptUserPermissions?: ScriptUserPermission[];
}
