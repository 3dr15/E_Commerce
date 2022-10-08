import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryService } from '../../../api/services';
import { Category } from '../../../api/models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryApiService {

  constructor(
    private readonly categoryService: CategoryService
  ) {

  }

  getCategoriesList(): Observable<Array<Category>> {
    return this.categoryService.apiCategoryGet();
  }
}