
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";
import { Status } from "../model/status";
import { User } from '../model/user';

const settings = require('../../../environments/settings.json');
@Injectable({
  providedIn: 'root'
})
export class UserService {

  private api: string = settings.apiUrl + "/User";
  constructor(private http: HttpClient){

  }

  getUsers(): Observable<User[]>{
    return this.http.get<User[]>(`${this.api}/GetUsers`);
  }
  getPendingUsers(): Observable<User[]>{
    return this.http.get<User[]>(`${this.api}/GetPendingUsers`);
  }
  getAllStatus(): Observable<Status[]>{
    return this.http.get<Status[]>(`${this.api}/GetAllStatus`);
  }
  getShareableUsers(): Observable<User[]>{
    return this.http.get<User[]>(`${this.api}/GetShareableUsers`);
  }
  getUserById(id: number): Observable<User>{
    return this.http.get<User>(`${this.api}/GetUserById?id=`+id);
  }
  updateUser(data: any): Observable<any>{
    return this.http.patch(`${this.api}/UpdateUser`,data);
  }
  delete(id: number): Observable<any>{
    return this.http.delete(`${this.api}/Delete?id=${id}`);
  }
  changePassword(data: any): Observable<any>{
    return this.http.patch(`${this.api}/ChangePassword`,data);
  }

}
