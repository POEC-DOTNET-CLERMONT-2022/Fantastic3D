import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { User } from 'src/models/user';
import { IUserList } from 'src/models/i-user-list';
// import { userInfo } from 'os';

@Injectable({
  providedIn: 'root'
})
export class ApiClientService {
  baseUrl: string = 'https://localhost:7164/api/';
  userEndpoint: string = 'User/';

  headers: { headers: HttpHeaders } = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
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
  getUserById(id: number): Observable<User> {
    return this.httpClient.get<User>(this.baseUrl + this.userEndpoint + id);
  }

  getUsers(): Observable<User[]> {
    return this.httpClient.get<User[]>(this.baseUrl + this.userEndpoint);
  }

  getUrlResult(url: string): Observable<User> {
    return this.httpClient.get<User>(url);
  }

}
