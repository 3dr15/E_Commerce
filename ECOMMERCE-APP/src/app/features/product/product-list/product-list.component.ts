import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { IPaginationParam, ProductApiService } from '../services/product-api.service';
import { Subscription } from 'rxjs';
import { ToastService } from '../../../shared/shared-toaster/toast.service';
import { Table } from 'primeng/table';
import { Product } from 'src/app/api/models';
import { Router } from '@angular/router';
import { LazyLoadEvent } from 'primeng/api';

@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit, OnDestroy {
  
  loading: boolean = true;
  @ViewChild('dt') table!: Table;
  products!: Array<Product>;
  subscription: Subscription = new Subscription();
  totalRecords: number = 0;
  rowsPerPage: number = 5;

  constructor(
    private readonly productApiService: ProductApiService,
    private readonly toastService: ToastService,
    private readonly router: Router,
  ) { }

  ngOnInit(): void {
    this.getProductList();
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  getProductList(paginationParam?: IPaginationParam): void {
    this.loading = true;
    this.subscription.add(
      this.productApiService.getProductList(paginationParam).subscribe({
        next: (responseData) => {
          this.products = responseData.item1 ?? [];
          this.totalRecords = responseData.item2 ?? 0;
          this.loading = false;
        },
        error: (errorData) => {
          console.error(errorData);
          this.loading = false;
          this.toastService.showDanger("Something went wrong!");
          this.toastService.showDanger(errorData);
        }
      })
    );
  }

  deleteProduct(productId: string): void {
    if (productId) {
      this.subscription.add(
        this.productApiService.deleteProduct(productId).subscribe({
          next: (responseData) => {
            this.getProductList();
          },
          error: (errorData) => {
            console.error(errorData);
            this.toastService.showDanger("Something went wrong!");
            this.toastService.showDanger(errorData);
          }
        })
      );
    }
  }

  goToEditProduct(productId: string): void {
    if (productId) {
      this.router.navigate(['edit-product', productId]); 
    }
  }

  loadProducts(event: LazyLoadEvent): void {
    this.getProductList({pageNumber: event.first? (event.first / this.rowsPerPage) + 1: 1, pageSize: this.rowsPerPage});
  }
}
