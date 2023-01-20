import { RewardPointsComponent } from './reward-points/reward-points.component';
import { UserAddEditComponent } from './user/add-edit/user-add-edit.component';
import { NgModule } from '@angular/core';
import { NbCardComponent, NbMenuModule, NbCardModule, NbButtonModule } from '@nebular/theme';
import { ThemeModule } from '../@theme/theme.module';
import { FeaturesComponent } from './features.component';
import { FeaturesRoutingModule } from './features-routing.module';
import {  UserListComponent } from './user/list/user-list.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { ComponentsModule } from '../@components/components.module';
import { ReactiveFormsModule } from '@angular/forms';
import { UserModule } from './user/user.module';
import { AccessDeniedComponent } from '../page/access-denied/access-denied.component';
import { SettingsModule } from './settings/settings.module';
import { OrderComponent } from './order/order.component';
import { ReportsComponent } from './reports/reports.component';

@NgModule({
  imports: [
    FeaturesRoutingModule,
    ThemeModule,
    NbMenuModule,
    Ng2SmartTableModule,
    NbCardModule,
    NbButtonModule,
    ComponentsModule,
    ReactiveFormsModule,
  ],
  declarations: [
    FeaturesComponent,
    DashboardComponent,
    OrderComponent,
    RewardPointsComponent,
    ReportsComponent,
  ],
})
export class FeaturesModule {
}
