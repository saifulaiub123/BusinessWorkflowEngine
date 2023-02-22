import { Component, OnInit, OnDestroy } from '@angular/core';
import { NbAuthService } from '@nebular/auth';
import { CookieService } from 'ngx-cookie-service';

const settings = require('../../../environments/settings.json');

@Component({
  selector: 'ngx-hangfire',
  templateUrl: './hangfire.component.html',
  styleUrls: ['./hangfire.component.scss']
})
export class HangfireComponent implements OnInit, OnDestroy {

  hangfireUrl: string;
  token: string;
  constructor(
    private _authService: NbAuthService,
    private _cookieService: CookieService) {
    this._authService.getToken().subscribe((data : any) =>{
      this.token = data.token;
      // this._cookieService.set('HangFireCookie', this.token );
      //document.cookie = `HangFireCookie=${this.token};Path=/`;
    })
   }

  ngOnInit(): void {
    this.hangfireUrl = settings.backendUrl + "/job/hangfire";
  }
  ngOnDestroy() {
    //document.cookie = 'HangFireCookie=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;'
  }
}
