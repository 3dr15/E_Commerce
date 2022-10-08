import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AbstractControl, ValidationErrors } from '@angular/forms';
import { ProductService } from '../../../api/services';
import { Product } from 'src/app/api/models';
import { AddProduct } from '../../../api/models/add-product';
import { UpdateProduct } from '../../../api/models/update-product';


export interface IPaginationParam {
  pageSize: number;
  pageNumber: number;
}

export class CustomValidator {
  static isEmpty(control: AbstractControl) : ValidationErrors | null {
    if((control.value === null || control.value === undefined) || ('string' === typeof(control.value) && (control.value as string)?.trim() === '')){
        return {isEmpty: true}
    }

    return null;
  }
}

@Injectable({
  providedIn: 'root'
})
export class ProductApiService {

  constructor(
    private readonly productService: ProductService
  ) {

  }

  getProductList(pagination: IPaginationParam): Observable<Array<Product>> {
    return this.productService.apiProductGet({
      pageSize: pagination.pageSize,
      pageNumber: pagination.pageNumber
    });
  }

  getProduct(productId: string): Observable<Product> {
    return this.productService.apiProductIdGet(
      {
        id: productId
      }
    );
  }

  addProduct(addProductInfo: AddProduct): Observable<Product> {
    return this.productService.apiProductPost({
      body: addProductInfo
    });
  }

  updateProduct(updateProduct: UpdateProduct): Observable<void> {
    return this.productService.apiProductIdPut({
      id: updateProduct.productId,
      body: updateProduct
    });
  }

  deleteProduct(productId: string): Observable<void> {
    return this.productService.apiProductIdDelete({
      id: productId
    });
  }
}