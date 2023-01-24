import { NbSelectModule } from '@nebular/theme';
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

const COMPONENTS = [
  NgxValidationMessageComponent,
  NgxFilterByNumberComponent,
  UserCustomActionComponent,
  ScriptActionComponent,
  CustomNbSelectComponent
];

@NgModule({
  imports: [
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    NbCheckboxModule,
    NbButtonModule,
    NbIconModule,
    NbSelectModule
  ],
  exports: [...COMPONENTS],
  declarations: [...COMPONENTS, CustomNg2CheckboxComponent, CustomDeleteComponent],
  entryComponents: [
    NgxFilterByNumberComponent,
  ],
})
export class ComponentsModule {
}
