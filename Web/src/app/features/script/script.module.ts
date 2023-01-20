import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEditComponent } from './add-edit/add-edit.component';
import { ScriptRoutingModule } from './script-routing-module';
import { ListComponent } from './list/list.component';
import { NbButtonModule, NbCardModule, NbCheckboxModule, NbInputModule, NbMenuModule, NbSpinnerModule } from '@nebular/theme';
import { ReactiveFormsModule } from '@angular/forms';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ComponentsModule } from '../../@components/components.module';
import { UserRoutingModule } from '../user/user-routing.module';



@NgModule({
  declarations: [
    AddEditComponent,
    ListComponent,
  ],
  imports: [
    CommonModule,
    ScriptRoutingModule,

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
  ]
})
export class ScriptModule { }
