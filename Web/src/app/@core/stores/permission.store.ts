
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Permission } from '../model/permission';

@Injectable({
  providedIn: 'root',
})
export class PermissionStore {
  private permission: Permission[] = [];

  protected permissionsState$ = new BehaviorSubject(this.permission);

  getUPermissions(): Permission[] {
    return this.permission;
  }

  setUPermissions(permissions: Permission[]) {
    this.permission = permissions;
    this.changeUserState(permissions);
  }

  // onUserStateChange() {
  //   return this.userState$.pipe(share());
  // }

  changeUserState(permissions: Permission[]) {
    this.permissionsState$.next(permissions);
  }

}
