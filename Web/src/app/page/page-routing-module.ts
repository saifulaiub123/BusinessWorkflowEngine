import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from '../auth/auth.guard';
import { PageComponent } from './page.component';
import { AccessDeniedComponent } from './access-denied/access-denied.component';

const routes: Routes = [{
  path: '',
  component: PageComponent,
  children: [
    {
      path: 'access-denied',
      component: AccessDeniedComponent,
    },
    {
      path: '',
      redirectTo: 'access-denied',
      pathMatch: 'full',
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PageRoutingModule {
}
