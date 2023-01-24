import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SmartTableSharedervice {

  private deleteRow$ = new BehaviorSubject<boolean>(false);

  idDeleteRow$ = this.deleteRow$.asObservable();

  constructor() {}
  deleteRow(row: any)
  {
    this.deleteRow$.next(row);
  }
}
