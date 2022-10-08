import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductAddEditComponent } from './product/product-add-edit/product-add-edit.component';

const routes: Routes = [
  { 
    path: '', 
    redirectTo: '/add-product', 
    pathMatch: 'full' 
  },
  {
    path: 'add-product',
    component: ProductAddEditComponent
  },
  {
    path: 'edit-product/:id',
    component: ProductAddEditComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class FeaturesRoutingModule { }
