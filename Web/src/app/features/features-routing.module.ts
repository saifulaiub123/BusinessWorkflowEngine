import { ReportsComponent } from './reports/reports.component';
import { RewardPointsComponent } from './reward-points/reward-points.component';
import { OrderComponent } from './order/order.component';
import { UserListComponent } from './user/list/user-list.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { FeaturesComponent } from './features.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { AuthGuard } from '../auth/auth.guard';

const routes: Routes = [{
  path: '',
  component: FeaturesComponent,
  children: [
    {
      path: 'dashboard',
      canActivate: [AuthGuard],
      component: DashboardComponent,
      data: {
        role: ['Admin','User','Partner']
      },
    },
    {
      path: 'user',
      canActivate: [AuthGuard],
      component: UserListComponent,
      data: {
        role: ['Admin']
      },
      loadChildren: () => import('./user/user.module')
      .then(m => m.UserModule),
    },
    {
      path: 'script',
      canActivate: [AuthGuard],
      data: {
        role: ['Admin','User']
      },
      loadChildren: () => import('./script/script.module')
      .then(m => m.ScriptModule),
    },
    // {
    //   path: 'settings',
    //   canActivate: [AuthGuard],
    //   data: {
    //     role: ['Admin','User','Partner']
    //   },
    //   loadChildren: () => import('./settings/settings.module')
    //   .then(m => m.SettingsModule),
    // },
    {
      path: '',
      redirectTo: 'dashboard',
      pathMatch: 'full',
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FeaturesRoutingModule {
}
