import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServerSharedService {
  private serverUpdated$ = new BehaviorSubject<boolean>(false);
  isServerUpdated$ = this.serverUpdated$.asObservable();

  private deleteServer$ = new BehaviorSubject<number>(0);
  isDeleteServer$ = this.deleteServer$.asObservable();

  constructor() {}

  setServerUpdateStatus(status: boolean)
  {
    this.serverUpdated$.next(status);
  }

  deleteServer(id: number)
  {
    this.deleteServer$.next(id);
  }
}
