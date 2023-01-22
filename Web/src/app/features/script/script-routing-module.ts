import { AuthGuard } from './../../auth/auth.guard';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { ListComponent } from './list/list.component';
import { ScriptAddEditComponent } from './add-edit/script-add-edit.component';

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
      component: ScriptAddEditComponent,
    },
    {
      path: 'add-edit/:id',
      canActivate: [AuthGuard],
      data: {
        role: ['Admin','User']
      },
      component: ScriptAddEditComponent,
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
