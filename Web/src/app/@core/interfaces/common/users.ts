import { Observable } from 'rxjs';
import { DataSource } from 'ng2-smart-table/lib/lib/data-source/data-source';
import { UserRole } from '../../model/user-role';
import { ILoginUser } from './ILoginUser';
export interface IUser {
  id?: number;
  firstName?: string;
  lastName?: string;
  email?: string;
  phoneNumber?: string;
  userRoles? : UserRole[];
}


export interface Address {
  street: string;
  city: string;
  zipCode: string;
}

export abstract class   UserData {
  abstract get gridDataSource(): DataSource;
  abstract getCurrentUser(): Observable<ILoginUser>;
  abstract list(pageNumber: number, pageSize: number): Observable<ILoginUser[]>;
  abstract get(id: number): Observable<ILoginUser>;
  abstract update(user: ILoginUser): Observable<ILoginUser>;
  abstract updateCurrent(user: ILoginUser): Observable<ILoginUser>;
  abstract create(user: ILoginUser): Observable<ILoginUser>;
  abstract delete(id: number): Observable<boolean>;
}
