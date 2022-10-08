import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductAddEditComponent } from './product/product-add-edit/product-add-edit.component';
import { ProductApiService } from './product/services/product-api.service';
import { FeaturesRoutingModule } from './features-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { CategoryApiService } from './product/services/category-api.service';
import { ProductListComponent } from './product/product-list/product-list.component';



@NgModule({
  declarations: [
    ProductAddEditComponent,
    ProductListComponent
  ],
  imports: [
    CommonModule,
    FeaturesRoutingModule,
    SharedModule,
    ReactiveFormsModule
  ],
  providers: [
    ProductApiService,
    CategoryApiService
  ]
})
export class FeaturesModule { }
