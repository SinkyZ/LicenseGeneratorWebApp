import { Component, OnInit } from '@angular/core';
import { ProductList } from './product-list';
import { ProductListService } from './product-list.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html'
})

export class ProductListComponent implements OnInit {

  title = 'ProductList';

  constructor(private productListService: ProductListService) { }

  products: ProductList[] = [];

  ngOnInit(): void {
    this.productListService.getProductList()
      .subscribe({
        next: (products) => {
          this.products = products;
          console.log(products)
        },
        error: (response) => {
          console.log(response);
        }
      });
  
  }

}


//SERVICES TO CALL ANY EXTERNAL API'S
