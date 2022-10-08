import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { NgbAlertModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedToasterComponent } from './shared-toaster/shared-toaster.component';
import { ToastService } from './shared-toaster/toast.service';
import { DropdownModule } from 'primeng/dropdown';
import { RadioButtonModule } from 'primeng/radiobutton';

import {CalendarModule} from 'primeng/calendar';
import {SliderModule} from 'primeng/slider';
import {DialogModule} from 'primeng/dialog';
import {MultiSelectModule} from 'primeng/multiselect';
import {ContextMenuModule} from 'primeng/contextmenu';
import {ButtonModule} from 'primeng/button';
import {ToastModule} from 'primeng/toast';
import {InputTextModule} from 'primeng/inputtext';
import {InputNumberModule} from 'primeng/inputnumber';
import {ProgressBarModule} from 'primeng/progressbar';
import {InputTextareaModule} from 'primeng/inputtextarea';



@NgModule({
  declarations: [
    SharedToasterComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
    TableModule,
    NgbAlertModule,
    DropdownModule,
    RadioButtonModule,
    SliderModule,
    DialogModule,
    MultiSelectModule,
    ContextMenuModule,
    ButtonModule,
    InputTextModule,
    InputNumberModule,
    InputTextareaModule,
    ProgressBarModule,
    CalendarModule
  ],
  exports: [
    SharedToasterComponent,
    TableModule,
    NgbAlertModule,
    DropdownModule,
    RadioButtonModule,
    SliderModule,
    DialogModule,
    MultiSelectModule,
    ContextMenuModule,
    ButtonModule,
    InputTextModule,
    InputNumberModule,
    InputTextareaModule,
    ProgressBarModule,
    CalendarModule
  ],
  bootstrap: [
    SharedToasterComponent
  ],
  providers: [
    ToastService
  ]
})
export class SharedModule { }
