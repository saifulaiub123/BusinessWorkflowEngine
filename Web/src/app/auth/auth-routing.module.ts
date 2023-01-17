import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { NgxAuthComponent } from './auth.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { LogoutComponent } from './components/logout/logout.component';

const routes: Routes = [{
  path: '',
  component: NgxAuthComponent,
  children: [
    {
      path: '',
      component: LoginComponent,
    },
    {
      path: 'login',
      component: LoginComponent,
    },
    {
      path: 'register',
      component: RegisterComponent,
    },
    {
      path: 'logout',
      component: LogoutComponent,
    }
    // {
    //   path: 'request-password',
    //   component: NgxRequestPasswordComponent,
    // },
    // {
    //   path: 'reset-password',
    //   component: NgxResetPasswordComponent,
    // },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {
}
