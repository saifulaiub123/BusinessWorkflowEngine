import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
const settings = require('../../../environments/settings.json');

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private api: string = settings.apiUrl + "/Auth";
  constructor(private http: HttpClient){

  }

  login(data: any): Observable<any>{
    return this.http.post(`${this.api}/Login`,data);
  }
}
