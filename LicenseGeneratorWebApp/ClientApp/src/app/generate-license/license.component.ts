import { Component, OnInit } from '@angular/core';
import { DefaultLicense } from './license';
import { LicenseService } from './license.service';

@Component({
  selector: 'app-generate-license',
  templateUrl: './license.component.html',
})
export class AddLicenseComponent implements OnInit {

  addNewLicense: DefaultLicense = {
    idLicense: '00000000-0000-0000-0000-000000000000',
    licenseContent: '',
    licenseType: '',
    expirationDate: '',
    idProdus: '',
    idClient: ''
  }
  constructor(private licenseService: LicenseService) { }

  ngOnInit(): void {

  }

  addLicense(): void {
    console.log("Test2")
    this.licenseService.addLicense(this.addNewLicense)
      .subscribe({
        next: (license) => {
          console.log(license)
          console.log("test")
        }
      })
  }
}
