import { UserRoutingModule } from './user-routing.module';
import { NgModule } from '@angular/core';
import { NbCardComponent, NbMenuModule, NbCardModule, NbButtonModule, NbInputModule, NbSpinnerModule, NbCheckboxModule } from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';

import { ReactiveFormsModule } from '@angular/forms';
import { ComponentsModule } from '../../@components/components.module';
import { UserListComponent } from './list/user-list.component';
import { UserAddEditComponent } from './add-edit/user-add-edit.component';
import { CommonModule } from '@angular/common';
import { UserListScriptModalComponent } from './modal/user-list-script-modal/user-list-script-modal.component';
import { UserPendingComponent } from './user-pending/user-pending.component';

@NgModule({
  imports: [
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
  ],
  declarations: [
    UserListComponent,
    UserAddEditComponent,
    UserListScriptModalComponent,
    UserPendingComponent
  ],
})
export class UserModule {
}
