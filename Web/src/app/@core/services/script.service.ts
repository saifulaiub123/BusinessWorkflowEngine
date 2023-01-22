import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Script } from '../model/script';

const settings = require('../../../environments/settings.json');
@Injectable({
  providedIn: 'root'
})
export class ScriptService {

  private api: string = settings.apiUrl + "/Script";
  constructor(private http: HttpClient){

  }

  addScript(script: Script): Observable<any>{
    return this.http.post(`${this.api}/AddScript`,script);
  }
  getScriptsByUserId(id: number): Observable<Script[]>{
    return this.http.get<Script[]>(`${this.api}/GetScriptsByUserId?userId=${id}`);
  }
  getScriptById(id: number): Observable<Script>{
    return this.http.get<Script>(`${this.api}/GetScriptById?id=${id}`);
  }
  updateScript(script: Script): Observable<any>{
    return this.http.patch(`${this.api}/UpdateScript`,script);
  }
  // deleteBooking(id: Number): Observable<any>{
  //   return this.http.delete<any>(`${this.api}/DeleteBooking?id=`+id);
  // }
}
