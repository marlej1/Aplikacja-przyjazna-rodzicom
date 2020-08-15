import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { User } from 'app/Models/User';
import { map } from 'rxjs/operators';
import { JwtHelperService } from "@auth0/angular-jwt";



@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.apiUrl + 'account/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: any;

  constructor(private http:HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', JSON.stringify(user.user));
           this.decodedToken = this.jwtHelper.decodeToken(user.token);
           console.log('decoded token', this.decodedToken);
          this.currentUser = user.user;

          return this.currentUser;
        }
      })
    );
  }

  register(user: User) {
    return this.http.post(this.baseUrl + 'register', user);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
     return !this.jwtHelper.isTokenExpired(token);
  }
  
}
