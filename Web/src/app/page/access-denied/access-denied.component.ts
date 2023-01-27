import { NbMenuService } from '@nebular/theme';
import { Component } from '@angular/core';
import { Location } from '@angular/common'
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-not-found',
  styleUrls: ['./access-denied.component.scss'],
  templateUrl: './access-denied.component.html',
})
export class AccessDeniedComponent {

  constructor(private menuService: NbMenuService,private location: Location,private router: Router) {
  }

  goBack() {
    this.location.back();
  }
  goToHome()
  {
    this.router.navigate(['feature/script']);
  }
}
