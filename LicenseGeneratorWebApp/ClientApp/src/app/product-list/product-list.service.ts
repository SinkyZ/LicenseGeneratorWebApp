import { Injectable, Component } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { ProductList } from './product-list';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})

export class ProductListService {
  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getProductList(): Observable<ProductList[]> {
    return this.http.get<ProductList[]>(this.baseApiUrl + '/api/ProductList');
  }

  addProduct(addNewProductRequest: ProductList): Observable<ProductList> {
    addNewProductRequest.idProdus = '00000000-0000-0000-0000-000000000000';
    return this.http.post<ProductList>(this.baseApiUrl + '/api/ProductList', addNewProductRequest);
  }
}


