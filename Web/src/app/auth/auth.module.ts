
import { NgModule, ModuleWithProviders } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpRequest } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import {
  NbAuthJWTInterceptor,
  NbAuthModule,
  NB_AUTH_TOKEN_INTERCEPTOR_FILTER,
  NbTokenLocalStorage,
} from '@nebular/auth';
import { AuthInterceptor } from '../@core/interceptor/auth.interceptor';
import { AuthGuard } from './auth.guard';
import { AdminGuard } from './admin.guard';
import { AuthPipe } from './auth.pipe';
import { RoleProvider } from './role.provider';
import { NbRoleProvider, NbSecurityModule } from '@nebular/security';
import {
  NbAlertModule,
  NbCardModule,
  NbIconModule,
  NbLayoutModule,
  NbCheckboxModule,
  NbInputModule,
  NbButtonModule,
} from '@nebular/theme';
import { AuthRoutingModule } from './auth-routing.module';
import { ComponentsModule } from '../@components/components.module';
import { authOptions } from './auth.settings';
import { authSettings } from './access.settings';
import { LogoutComponent } from './components/logout/logout.component';
import { LoginComponent } from './components/login/login.component';
import { NgxAuthComponent } from './auth.component';
import { RegisterComponent } from './components/register/register.component';
import { DateHttpInterceptor } from '../@core/interceptor/date-http-interceptor';

const GUARDS = [AuthGuard, AdminGuard];
const PIPES = [AuthPipe];
const COMPONENTS = [
  LoginComponent,
  NgxAuthComponent,
  LogoutComponent,
  RegisterComponent,
  //RequestPasswordComponent,
  //ResetPasswordComponent,
  //AuthBlockComponent,
];

const NB_MODULES = [
  NbIconModule,
  NbLayoutModule,
  NbCardModule,
  NbAlertModule,
  NbCheckboxModule,
  NbInputModule,
  NbButtonModule,
];

export function filterInterceptorRequest(req: HttpRequest<any>): boolean {
  return ['/auth/login', '/auth/register', '/auth/request-pass', '/auth/refresh-token']
    .some(url => req.url.includes(url));
}

@NgModule({
  declarations: [...PIPES, ...COMPONENTS],
  imports: [
    AuthRoutingModule,
    ReactiveFormsModule,
    CommonModule,
    ComponentsModule,
    ...NB_MODULES,
    NbAuthModule.forRoot(authOptions),
  ],
  exports: [...PIPES],
  providers: [
    NbSecurityModule.forRoot({
      accessControl: authSettings,
    }).providers,
    {
      provide: NbRoleProvider, useClass: RoleProvider,
    },
    {
      provide: NbTokenLocalStorage, useClass: NbTokenLocalStorage,
    },
  ],
})
export class AuthModule {
  static forRoot(): ModuleWithProviders<AuthModule> {
    return {
      ngModule: AuthModule,
      providers: [
        { provide: NB_AUTH_TOKEN_INTERCEPTOR_FILTER, useValue: filterInterceptorRequest },
        { provide: HTTP_INTERCEPTORS, useClass: NbAuthJWTInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
        // { provide: HTTP_INTERCEPTORS, useClass: DateHttpInterceptor, multi: true },

        ...GUARDS],
    };
  }
}
