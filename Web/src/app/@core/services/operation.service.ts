import { OperationModel } from './../model/operation-model';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { environment } from "../../../environments/environment";
import { OperationPageModel } from "../model/operation-page-model";
import { OperationViewModel } from '../model/operation-view-model';

@Injectable({
  providedIn: 'root'
})
export class OperationService {

  private api: string = environment.apiUrl + "/Operation";
  constructor(private http: HttpClient){

  }

  getInitialPageData(): Observable<OperationPageModel>{
    return this.http.get<OperationPageModel>(`${this.api}/GetInitialPageData`);
  }
  getOperations(): Observable<OperationViewModel[]>{
    return this.http.get<OperationViewModel[]>(`${this.api}/GetOperations`);
  }
  getOperationById(id: Number): Observable<OperationViewModel>{
    return this.http.get<OperationViewModel>(`${this.api}/GetOperationById?id=`+id);
  }
  addOperation(operation: OperationModel): Observable<any>{
    return this.http.post(`${this.api}/AddOperation`,operation);
  }
  updateOperation(operation: OperationModel): Observable<any>{
    return this.http.patch(`${this.api}/UpdateOperation`,operation);
  }
  deleteOperation(id: Number): Observable<any>{
    return this.http.delete<any>(`${this.api}/DeleteOperation?id=`+id);
  }
}
