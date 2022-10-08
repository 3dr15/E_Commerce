import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomValidator, ProductApiService } from '../services/product-api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ToastService } from '../../../shared/shared-toaster/toast.service';
import { Category, Product } from 'src/app/api/models';
import { CategoryApiService } from '../services/category-api.service';

@Component({
  selector: 'product-add-edit',
  templateUrl: './product-add-edit.component.html'
})
export class ProductAddEditComponent implements OnInit, OnDestroy {

  productFormGroup!: FormGroup;
  subscription: Subscription = new Subscription();
  product!: Product;
  isEditForm!: boolean;
  categories: Array<Category> = [];
  minDate: Date;
  constructor(
    private readonly productApiService: ProductApiService,
    private readonly categoryApiService: CategoryApiService,
    private readonly formBuilder: FormBuilder,
    private readonly activeRoute:  ActivatedRoute,
    private readonly router: Router,
    private readonly toastService: ToastService
  ) {
    const tomorrowsDate = new Date();
    tomorrowsDate.setDate(tomorrowsDate.getDate() + 1);
    this.minDate = tomorrowsDate;
    this.getCategories();
    this.initializeFormGroup();
  }

  getCategories() {
    this.subscription.add(
      this.categoryApiService.getCategoriesList().subscribe({
        next: (responseData) => {
          this.categories = responseData;
        },
        error: (errorResponse) => {
          console.error(errorResponse);
        }
      })
    );
  }

  ngOnInit(): void {

  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  get categoryName(): string | undefined {
    return this.categories.find(x => x.categoryId === this.productFormGroup.get('categoryId')?.value)?.name;
  }

  getProduct(productId: string): void {
    this.subscription.add(
      this.productApiService.getProduct(productId).subscribe({
        next: (responseData) => {
          this.fillProductFormGroup(responseData);
        },
        error: (errorData) => {
          console.error(errorData);
        }
      })
    );
  }

  save(): void {
    if (this.productFormGroup.valid) {
      if(this.isEditForm) {
        this.updateProduct();
      } else {
        this.addProduct();
      }
    } else {
      this.productFormGroup.markAllAsTouched();
    }
  }

  quit(): void {
    this.router.navigate(['add-product']);
  }
    
  private addProduct() {
    this.subscription.add(
      this.productApiService.addProduct(this.productFormGroup.value).subscribe({
        next: (responseData) => {
          this.fillProductFormGroup(responseData);
          this.toastService.showStandard('Saved Successfully.');
          this.router.navigate(['edit-product', responseData.productId]);
        },
        error: (errorData) => {
          console.error(errorData);
          this.toastService.showDanger('Error occurred!');
        }
      })
    );
  }

  private updateProduct() {
    this.subscription.add(
      this.productApiService.updateProduct(this.productFormGroup.value).subscribe({
        next: (responseData) => {
          this.toastService.showStandard('Successfully Updated.');
          this.router.navigate(['edit-product', this.productFormGroup.value.productId]);
        },
        error: (errorData) => {
          console.error(errorData);
          this.toastService.showDanger('Error occurred!');
        }
      })
    );
  }

  private initializeFormGroup() {
    this.productFormGroup = this.formBuilder.group({
      productId: [undefined],
      name: [undefined, [Validators.required, CustomValidator.isEmpty]],
      price: [undefined,  [Validators.required, CustomValidator.isEmpty]],
      description: [undefined, [Validators.required, Validators.maxLength(500), CustomValidator.isEmpty]],
      categoryId: [undefined, [Validators.required]],
      expiryDate: [undefined]
    });

    // {
    //   expiryDate?: null | string; should not be less than todays date 
    // }

    if(this.activeRoute.snapshot.params['id']) {
      this.getProduct(this.activeRoute.snapshot.params['id']);
      this.isEditForm = true;
    } else {
      this.isEditForm = false;
    }
  }
    
  private fillProductFormGroup(responseData: Product) {
    this.productFormGroup.setValue({
      productId: responseData.productId,
      name: responseData.name,
      price: responseData.price,
      description: responseData.description,
      categoryId: responseData.categoryId,
      expiryDate: responseData.expiryDate ? new Date(responseData.expiryDate ?? '') : undefined
    });
  }
}
