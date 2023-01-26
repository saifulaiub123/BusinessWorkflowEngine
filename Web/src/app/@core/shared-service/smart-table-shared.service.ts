import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SmartTableSharedervice {

  private deleteRow$ = new BehaviorSubject<boolean>(false);

  private deleteScript$ = new BehaviorSubject<boolean>(false);
  private deleteSharedUser$ = new BehaviorSubject<boolean>(false);



  idDeleteRow$ = this.deleteRow$.asObservable();

  isDeleteScript$ = this.deleteScript$.asObservable();
  isDeleteSharedUser$ = this.deleteSharedUser$.asObservable();

  constructor() {}
  deleteScript(row: any)
  {
    this.deleteScript$.next(row);
  }

  deleteSharedUser(row: any)
  {
    this.deleteSharedUser$.next(row);
  }

  deleteRow(row: any)
  {
    this.deleteRow$.next(row);
  }
}
