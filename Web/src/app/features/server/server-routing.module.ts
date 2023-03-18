import { ServerListComponent } from './list/list.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../../auth/auth.guard';
import { ServerAddEditComponent } from './add-edit/add-edit.component';

const routes: Routes = [{
  path: '',
  children: [
    {
      path: 'list',
      canActivate: [AuthGuard],
      data: {
        role: ['Admin']
      },
      component: ServerListComponent,
    },
    {
      path: 'add-edit',
      canActivate: [AuthGuard],
      data: {
        role: ['Admin']
      },
      component: ServerAddEditComponent,
    },
    {
      path: '',
      redirectTo: 'list',
      pathMatch: 'full',
    },
  ],
}];
export const ServerRoutingRoutes = RouterModule.forChild(routes);
