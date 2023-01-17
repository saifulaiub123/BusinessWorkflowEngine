import { UserAddEditComponent } from './add-edit/user-add-edit.component';
import { UserListComponent } from './list/user-list.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from '../../auth/auth.guard';

const routes: Routes = [{
  path: '',
  children: [
    {
      path: 'list',
      canActivate: [AuthGuard],
      data: {
        role: ['Admin']
      },
      component: UserListComponent,
    },
    {
      path: 'add-edit',
      canActivate: [AuthGuard],
      data: {
        role: ['Admin']
      },
      component: UserAddEditComponent,
    },
    {
      path: '',
      redirectTo: 'list',
      pathMatch: 'full',
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserRoutingModule {
}
