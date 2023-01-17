import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { Role } from '../model/role';
@Injectable({
  providedIn: 'root'
})
export class RoleService {

  private api: string = environment.apiUrl + "/Role";
  constructor(private http: HttpClient){

  }

  getRoles(): Observable<Role[]>{
    return this.http.get<Role[]>(`${this.api}/GetRoles`);
  }
}
