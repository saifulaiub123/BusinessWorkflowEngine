
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Server } from "../model/server";

const settings = require('../../../environments/settings.json');
@Injectable({
  providedIn: 'root'
})
export class ServerService {

  private api: string = settings.apiUrl + "/Server";
  constructor(private http: HttpClient){

  }

  getAllServer(): Observable<Server[]>{
    return this.http.get<Server[]>(`${this.api}/GetAllServer`);
  }


}
