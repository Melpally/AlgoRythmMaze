import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { LoginModel } from '../models/account/login-model';
import {CookieService} from "ngx-cookie-service";
import { environment } from '../../environment';
import { ApiRoutes } from '../api.routes';
import { SignUpModel } from '../models/account/signup-model';
@Injectable({
  providedIn: 'root'
})

export class AuthService {
    constructor(private http: HttpClient, private cookieService : CookieService) {  }

  public performLogIn(loginModel: LoginModel): Observable<string> {
    const formData = new FormData();
    formData.append('Email', loginModel.Email);
    formData.append('Password', loginModel.Password);
    return this.http.post<string>(ApiRoutes.Login, formData, { responseType: 'text' as 'json', withCredentials: true });
    }
    public performSignUp(signUpModel: SignUpModel): Observable<string> {
        const formData = new FormData();
        formData.append('FullName', signUpModel.Fullname);
        formData.append('Email', signUpModel.Email);
        formData.append('Password', signUpModel.Password);
        formData.append('UserRole', signUpModel.UserRole.toString());
        formData.append('PhoneNumber', signUpModel.Phone);
        return this.http.post<string>(ApiRoutes.Register, formData, { responseType: 'text' as 'json' });
      }
    
    getToken(): string | undefined {
        return this.cookieService.get(environment.cookieKey);
    }
    isAuthenticated() : boolean {
        if (this.cookieService.get(environment.cookieKey))
        {
          return true;
        }
        return false;
      }
    
      public performSignOut() : Observable<any> {
    
        if(this.cookieService.check(environment.cookieKey))
        {
          this.cookieService.delete(environment.cookieKey);
        }
    
        return this.http.post<any>(ApiRoutes.LogOut, "");
      }
}