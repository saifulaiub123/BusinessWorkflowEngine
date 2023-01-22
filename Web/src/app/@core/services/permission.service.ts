
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Permission } from "../model/permission";
import { Server } from "../model/server";

const settings = require('../../../environments/settings.json');
@Injectable({
  providedIn: 'root'
})
export class PermissionService {

  private api: string = settings.apiUrl + "/Permission";
  constructor(private http: HttpClient){

  }

  getAllPermission(): Observable<Permission[]>{
    return this.http.get<Permission[]>(`${this.api}/GetAllPermission`);
  }


}
