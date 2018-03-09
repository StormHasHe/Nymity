import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Constants } from '../constants';
import { Subject }    from 'rxjs/Subject';
import { User } from '../models/user';
import { UserRegisterModel } from '../models/userRegisterModel';
 
@Injectable()
export class LoginService {
  private onLoginSource = new Subject();
 
  // Observable string streams
  onLogin$ = this.onLoginSource.asObservable();
 
  constructor(public api:ApiService, public constants:Constants) { }
 
  onUserLogin(){
    this.onLoginSource.next();
  }
 
  postRegister(username:string, password:string, confirmPassword:string){
    let body = new URLSearchParams();
    
    let user:UserRegisterModel = {
      email: username,
      password: password,
      confirmpassword: confirmPassword
    }
 
    return this.api.httpPostJson(this.constants.POST_REGISTER, JSON.stringify(user));
  }
  postLogin(username:string, password:string){
    let body = new URLSearchParams();
    
    body.append('grant_type', 'password');
    body.append('username', username);
    body.append('password', password);
 
    return this.api.httpPostUrlEncoded(this.constants.POST_TOKEN, body.toString());
  }
 
  isUserAuthenticated(user:User){
    return this.api.httpAuthorizedGet(this.constants.GET_TOKEN_VALID, user);
  }
}