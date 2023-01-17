import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize, map } from 'rxjs/operators';
import { NbAuthService, NbTokenService } from '@nebular/auth';
import { NbToastrService } from '@nebular/theme';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  private headers : any = {};
  constructor(private router: Router,private authService: NbAuthService,private tokenService: NbTokenService,private toastrService: NbToastrService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    this.authService.getToken().subscribe((data : any) =>{
      const token = data.token;
      if(token)
      {
        req = req.clone({
            setHeaders: {Authorization: `Bearer ${token}`}
        });
        //return next.handle(req);
      }
    })

    for (let key in req.body) {
      if (req.body[key] === '') {
        req.body[key] = null;
      }
    }
    return next.handle(req)
      .pipe(catchError((error: HttpErrorResponse) => {
        if (error.status === 401) {
          this.tokenService.clear();
          this.router.navigate(['auth/login']);
        }
        this.toastrService.show('Error',error.message,{ duration : 10000, status : 'danger' });
        return throwError(error);
      }
      ));
  }
}
