import { ProfileComponent } from './profile/profile.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from '../../auth/auth.guard';

const routes: Routes = [{
  path: '',
  children: [
    {
      path: 'profile',
      canActivate: [AuthGuard],
      data: {
        role: ['Admin','User','Partner']
      },
      component: ProfileComponent,
    },
    {
      path: '',
      redirectTo: 'profile',
      pathMatch: 'full',
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SettingsRoutingModule {
}
