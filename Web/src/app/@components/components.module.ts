import { NbCardModule, NbInputModule, NbSelectModule } from '@nebular/theme';
/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */

import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgxValidationMessageComponent } from './validation-message/validation-message.component';
import {
  NgxFilterByNumberComponent,
} from './custom-smart-table-components/filter-by-number/filter-by-number.component';

import { NbButtonModule, NbCheckboxModule, NbIconModule } from '@nebular/theme';
import { CustomNg2CheckboxComponent } from './custom-smart-table-components/custom-checkbox/custom-checkbox.component';
import { UserCustomActionComponent } from './custom-smart-table-components/user-custom-action/user-custom-action.component';
import { ScriptActionComponent } from './custom-smart-table-components/script-action-component/script-action.component';
import { CustomNbSelectComponent } from './custom-smart-table-components/custom-nb-select/custom-nb-select.component';
import { CustomDeleteComponent } from './custom-smart-table-components/custom-delete/custom-delete.component';
import { ConfirmModalComponent } from './modal/confirm-modal/confirm-modal.component';
import { BackComponent } from './back/back.component';
import { ScriptRunConfirmationComponent } from './modal/script-run-confirmation/script-run-confirmation.component';
import { ScriptHistoryResultComponent } from './custom-smart-table-components/script-history-result/script-history-result.component';
import { ShowContentComponent } from './modal/show-content/show-content.component';
import { ScriptHistoryStatusComponent } from './custom-smart-table-components/script-history-status/script-history-status.component';

const COMPONENTS = [
  NgxValidationMessageComponent,
  NgxFilterByNumberComponent,
  UserCustomActionComponent,
  ScriptActionComponent,
  CustomNbSelectComponent,
  ConfirmModalComponent,
  CustomDeleteComponent,
  CustomNg2CheckboxComponent,
  BackComponent
];

@NgModule({
  imports: [
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    NbCheckboxModule,
    NbButtonModule,
    NbIconModule,
    NbSelectModule,
    NbCardModule,
    NbInputModule
  ],
  exports: [...COMPONENTS],
  declarations: [...COMPONENTS, ScriptRunConfirmationComponent, ScriptHistoryResultComponent, ShowContentComponent, ScriptHistoryStatusComponent],
  entryComponents: [
    NgxFilterByNumberComponent,
  ],
})
export class ComponentsModule {
}
