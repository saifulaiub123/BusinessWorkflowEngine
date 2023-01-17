import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { PageRoutingModule } from './page-routing-module';
import { PageComponent } from './page.component';
import { ThemeModule } from '../@theme/theme.module';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { NbMenuModule, NbCardModule, NbButtonModule } from '@nebular/theme';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ComponentsModule } from '../@components/components.module';



@NgModule({
  declarations: [AccessDeniedComponent, PageComponent],
  imports: [
    CommonModule,
    PageRoutingModule,
    ThemeModule,
    NbMenuModule,
    Ng2SmartTableModule,
    NbCardModule,
    NbButtonModule,
    ComponentsModule,
    ReactiveFormsModule,
  ]
})
export class PageModule { }
