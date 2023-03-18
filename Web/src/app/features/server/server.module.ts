import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ServerListComponent } from './list/list.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NbMenuModule, NbCardModule, NbButtonModule, NbInputModule, NbSpinnerModule, NbCheckboxModule, NbSelectModule, NbIconModule } from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ComponentsModule } from '../../@components/components.module';
import { UserRoutingModule } from '../user/user-routing.module';
import { ServerAddEditComponent } from './add-edit/add-edit.component';



@NgModule({
  declarations: [
    ServerListComponent,
    ServerAddEditComponent
  ],
  imports: [
    CommonModule,
    NbMenuModule,
    Ng2SmartTableModule,
    NbCardModule,
    NbButtonModule,
    ComponentsModule,
    ReactiveFormsModule,
    UserRoutingModule,
    NbInputModule,
    NbSpinnerModule,
    CommonModule,
    NbCardModule,
    NbCheckboxModule,
    NbSelectModule,
    NbIconModule
  ]
})
export class ServerModule { }
