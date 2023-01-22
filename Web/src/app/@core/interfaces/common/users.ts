/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */

import { Observable } from 'rxjs';
import { DataSource } from 'ng2-smart-table/lib/lib/data-source/data-source';
import { Settings } from './settings';
import { UserRole } from '../../model/user-role';

// export interface User {
//   id: number;
//   role: string;
//   firstName: string;
//   lastName: string;
//   email: string;
//   name?: string;
//   age: number;
//   login: string;
//   picture: string;
//   address: Address;
//   settings: Settings;
// }

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
  abstract getCurrentUser(): Observable<IUser>;
  abstract list(pageNumber: number, pageSize: number): Observable<IUser[]>;
  abstract get(id: number): Observable<IUser>;
  abstract update(user: IUser): Observable<IUser>;
  abstract updateCurrent(user: IUser): Observable<IUser>;
  abstract create(user: IUser): Observable<IUser>;
  abstract delete(id: number): Observable<boolean>;
}
