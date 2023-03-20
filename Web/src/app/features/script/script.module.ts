import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ScriptAddEditComponent } from './add-edit/script-add-edit.component';
import { ScriptRoutingModule } from './script-routing-module';
import { ListComponent } from './list/list.component';
import { NbActionsModule, NbAlertModule, NbAutocompleteModule, NbButtonModule, NbCardModule, NbCheckboxModule, NbDatepickerModule, NbDialogModule, NbIconModule, NbInputModule, NbMenuModule, NbPopoverModule, NbRadioModule, NbSearchModule, NbSelectModule, NbSpinnerModule, NbTabsetModule, NbTimepickerModule, NbUserModule } from '@nebular/theme';
import { ReactiveFormsModule } from '@angular/forms';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ComponentsModule } from '../../@components/components.module';
import { UserRoutingModule } from '../user/user-routing.module';
import { NgbTimepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ThemeModule } from '../../@theme/theme.module';
import { ScriptHistoryComponent } from './script-history/script-history.component';



@NgModule({
  declarations: [
    ScriptAddEditComponent,
    ListComponent,
    ScriptHistoryComponent,
  ],
  imports: [
    CommonModule,
    ScriptRoutingModule,
    NbTabsetModule,

    NbCardModule,
    NbPopoverModule,
    NbSearchModule,
    NbIconModule,
    NbAlertModule,
    ThemeModule,

    NbInputModule,
    NbButtonModule,
    NbActionsModule,
    NbUserModule,
    NbCheckboxModule,
    NbRadioModule,
    NbDatepickerModule,
    NbSelectModule,
    // ngFormsModule,

    ReactiveFormsModule,
    Ng2SmartTableModule,
    NbTimepickerModule,
    NbAutocompleteModule,
    ComponentsModule,
    NbDialogModule.forChild(),
    NgbTimepickerModule
  ]
})
export class ScriptModule { }
