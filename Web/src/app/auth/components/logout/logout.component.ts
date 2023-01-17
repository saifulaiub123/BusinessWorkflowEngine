
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { NB_AUTH_OPTIONS, NbAuthService, NbAuthResult, NbTokenService } from '@nebular/auth';
import { getDeepFromObject } from '../../helpers';

@Component({
  selector: 'ng-logout',
  templateUrl: './logout.component.html',
})
export class LogoutComponent implements OnInit {

  redirectDelay: number = this.getConfigValue('forms.logout.redirectDelay');
  strategy: string = this.getConfigValue('forms.logout.strategy');

  constructor(protected service: NbAuthService,
              @Inject(NB_AUTH_OPTIONS) protected options = {},
              protected router: Router,
              protected tokenService: NbTokenService) { }

  ngOnInit(): void {
    this.logout();
  }

  logout(): void {
    this.tokenService.clear();
        setTimeout(() => {
          return this.router.navigateByUrl("/auth/login");
        }, this.redirectDelay);
  }

  getConfigValue(key: string): any {
    return getDeepFromObject(this.options, key, null);
  }
}
