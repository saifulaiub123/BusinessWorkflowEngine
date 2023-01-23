/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */

import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { UserStore } from '../../@core/stores/user.store';
import { Inject, Injectable } from '@angular/core';
import { NbJSThemesRegistry, NbThemeService } from '@nebular/theme';
import { ILoginUser } from '../../@core/interfaces/common/ILoginUser';

@Injectable()
export class InitUserService {
    constructor(protected userStore: UserStore,
      // @Inject(UserData) protected usersService: UserData,
        protected jsThemes: NbJSThemesRegistry,
        protected themeService: NbThemeService) { }

    // initCurrentUser(): Observable<IUser> {
    //   return this.usersService.getCurrentUser()
    //         .pipe(tap((user: IUser) => {
    //             if (user) {
    //               this.userStore.setUser(user);

    //               // if (user.settings && user.settings.themeName) {
    //               //   if (this.jsThemes.has(user.settings.themeName)) {
    //               //     this.themeService.changeTheme(user.settings.themeName);
    //               //   }
    //               // }
    //             }
    //         }));
    // }

    initCurrentUser(){
      let user : ILoginUser = JSON.parse(localStorage.getItem("UserData"));
      this.userStore.setUser(user);
    }
    getCurrentUser(){
      return this.userStore.getUser();
    }
}
