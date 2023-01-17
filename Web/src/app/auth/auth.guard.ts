import { Injectable } from '@angular/core';
import { NbAuthService } from '@nebular/auth';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router} from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private authService: NbAuthService, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot,
  ): Observable<boolean> | Promise<boolean> | boolean {
    return this.authService.isAuthenticated()
      .pipe(
        tap(authenticated => {
          if (!authenticated) {
            this.router.navigate(['auth/login']);
          }
          return this.checkUserRole(route,state.url);
        }),
      );

  }
  checkUserRole(route: ActivatedRouteSnapshot, url: any): boolean {
    if (this.authService.isAuthenticated()) {
      const userRoles = (JSON.parse(localStorage.getItem("UserData")).role).split(',');
      if (route.data.role) {
        const found = userRoles.find((val, index) => {
           return route.data.role.includes(val)
        })
      if(found === undefined)
        {
          this.router.navigate(['/page/access-denied']);
        }
      }
      return true;
    }
    return false;
  }
}


