import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { SettingsRoutingModule } from './settings-routing-module';
import { NbButtonModule, NbCardModule, NbCheckboxModule, NbInputModule, NbMenuModule, NbSpinnerModule } from '@nebular/theme';
import { ReactiveFormsModule } from '@angular/forms';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ComponentsModule } from '../../@components/components.module';
import { UserRoutingModule } from '../user/user-routing.module';
import { ChangePasswordComponent } from './change-password/change-password.component';



@NgModule({
  declarations: [
    ProfileComponent,
    ChangePasswordComponent
  ],
  imports: [
    CommonModule,
    SettingsRoutingModule,
    NbCardModule,
    NbCheckboxModule,
    NbSpinnerModule,
    NbMenuModule,
    Ng2SmartTableModule,
    NbButtonModule,
    ComponentsModule,
    ReactiveFormsModule,
    UserRoutingModule,
    NbInputModule,
  ]
})
export class SettingsModule { }
