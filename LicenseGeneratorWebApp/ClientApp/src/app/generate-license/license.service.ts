import { Injectable, Component } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { DefaultLicense } from './license';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})

export class LicenseService {
  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }


  addLicense(addNewLicense: DefaultLicense): Observable<DefaultLicense> {
    return this.http.post<DefaultLicense>(this.baseApiUrl + '/api/License', addNewLicense);
  }

}
