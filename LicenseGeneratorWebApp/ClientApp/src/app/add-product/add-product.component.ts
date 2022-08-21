import { Component, OnInit } from '@angular/core';
import { ProductList } from '../product-list/product-list';
import { ProductListService } from '../product-list/product-list.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
})
export class AddProductComponent implements OnInit {

  addNewProductRequest: ProductList = {
      idProdus: '00000000-0000-0000-0000-000000000000',
      numeProdus: '',
      shortCode: '',
      status: 'Active'
  }
  constructor(private productService: ProductListService) { }

  ngOnInit(): void {
        
  }

  addProduct(): void {
    this.productService.addProduct(this.addNewProductRequest)
      .subscribe({
        next: (product) => {
          console.log(product)
        }
      })
  }
}
