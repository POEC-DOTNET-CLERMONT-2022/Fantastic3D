import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { User } from 'src/models/user';
import { IUserList } from 'src/models/i-user-list';
import { IUser } from 'src/models/i-user';
// import { userInfo } from 'os';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {
  baseUrl: string = 'https://localhost:7164/api/';
  
  headers: {headers: HttpHeaders} = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      Authorization: 'my-auth-token'
    })
  };

  constructor(private httpClient: HttpClient) { }

  postUser(user: User): Observable<User> {
    const body = {
        id: user.id,
        username: user.username,
        firstName: user.firstName,
        lastName: user.lastName,
        email: user.email,
        password: user.password,
        billingAddress: user.billingAddress,
        role: user.role,
    }
    return this.httpClient.post<User>(
      this.baseUrl + "User/",
      body,
      this.headers);
  }
  getUserById(id: number): Observable<IUser> {
    return this.httpClient.get<IUser>(this.baseUrl + 'User/' + id);
  }

  getUsersByOffset(offset: number, limit: number = 20): Observable<IUserList> {
    return this.httpClient.get<IUserList>(this.baseUrl + 'User/');
    //return this.httpClient.get<IUserList>(this.baseUrl + 'User');
    // TODO : ajouter une pagination, requêtes : 'user/?offset='+offset+'&limit='+limit);
  }

  getUrlResult(url: string): Observable<IUser> {
    return this.httpClient.get<IUser>(url);
  }

}
