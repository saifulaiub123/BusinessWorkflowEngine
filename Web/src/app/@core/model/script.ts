import { ScriptUserPermission } from "./script-user-permission";

export class Script {
  id?: number;
  name?: string;
  destinationServerId?: string;
  destinationServerName?: string;
  content?: string;
  createdBy?: number;
  scriptUserPermissions?: ScriptUserPermission[];
}
