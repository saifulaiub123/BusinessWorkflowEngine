import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ScriptHistory } from '../model/script-history';
const settings = require('../../../environments/settings.json');

@Injectable({
  providedIn: 'root'
})
export class ScriptHistoryService {

  private api: string = settings.apiUrl + "/ScriptHistory";
  constructor(private http: HttpClient){

  }

  getByUserId(id:number): Observable<ScriptHistory[]>{
    return this.http.get<ScriptHistory[]>(`${this.api}/GetByUserId?userId=`+id);
  }


}
