
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { share } from 'rxjs/operators';
import { ILoginUser } from '../interfaces/common/ILoginUser';

@Injectable({
  providedIn: 'root',
})
export class UserStore {
  private user: ILoginUser = {};

  protected userState$ = new BehaviorSubject(this.user);

  getUser(): ILoginUser {
    return this.user;
  }

  setUser(paramUser: ILoginUser) {
    this.user = paramUser;
    this.changeUserState(paramUser);
  }

  onUserStateChange() {
    return this.userState$.pipe(share());
  }

  changeUserState(paramUser: ILoginUser) {
    this.userState$.next(paramUser);
  }

  // setSetting(themeName: string) {
  //   if (this.user) {
  //     if (this.user.settings) {
  //       this.user.settings.themeName = themeName;
  //     } else {
  //       this.user.settings = { themeName: themeName };
  //     }

  //     this.changeUserState(this.user);
  //   }
  // }
}
