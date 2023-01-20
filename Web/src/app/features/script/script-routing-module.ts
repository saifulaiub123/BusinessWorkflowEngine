import { AuthGuard } from './../../auth/auth.guard';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AddEditComponent } from './add-edit/add-edit.component';
import { ListComponent } from './list/list.component';

const routes: Routes = [{
  path: '',
  children: [
    {
      path: 'list',
      canActivate: [AuthGuard],
      data: {
        role: ['Admin','User']
      },
      component: ListComponent,
    },
    {
      path: 'add-edit',
      canActivate: [AuthGuard],
      data: {
        role: ['Admin','User']
      },
      component: AddEditComponent,
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
export class ScriptRoutingModule {
}
