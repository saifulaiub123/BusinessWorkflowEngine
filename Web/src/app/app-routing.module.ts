import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuard } from './auth/auth.guard';

export const routes: Routes = [
  {
    path: 'page',
    loadChildren: () => import('./page/page.module')
      .then(m => m.PageModule),
  },
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule),
  },
  {
    path: 'feature',
    canActivate: [AuthGuard],
    data: {
      role: ['Admin','User','Partner']
    },
    loadChildren: () => import('./features/features.module').then(m => m.FeaturesModule),
  },
  { path: '', redirectTo: 'auth', pathMatch: 'full' },
  { path: '**', redirectTo: 'auth' },
];

const config: ExtraOptions = {
  useHash: false,
};

@NgModule({
  imports: [RouterModule.forRoot(routes, config)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
