
import { UserStore } from '../../@core/stores/user.store';
import { Injectable } from '@angular/core';
import { NbJSThemesRegistry, NbThemeService } from '@nebular/theme';
import { ILoginUser } from '../../@core/interfaces/common/ILoginUser';

@Injectable()
export class InitUserService {
    constructor(protected userStore: UserStore,
        protected jsThemes: NbJSThemesRegistry,
        protected themeService: NbThemeService) { }

    initCurrentUser(){
      let user : ILoginUser = JSON.parse(localStorage.getItem("UserData"));
      this.userStore.setUser(user);
    }
    getCurrentUser(){
      return this.userStore.getUser();
    }
    getCurrentUserRoles(){
      return this.userStore.getUser().role;
    }
}
