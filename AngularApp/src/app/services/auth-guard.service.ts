import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { User } from '../models/user';
import { LoginService } from './login.service';
import 'rxjs/add/operator/catch';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
 

@Injectable()
export class AuthGuardService implements CanActivate {
 
  constructor(private loginService:LoginService, private router:Router) { }
 
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
    return this.userAuthenticated(true);
  }
  
  userAuthenticated(redirectToHome:boolean)
  {
    let user = <User>JSON.parse(localStorage.getItem("user"));
    return this.loginService.isUserAuthenticated(user).map(response => {      
      return true;
    }).catch(error => {
      localStorage.removeItem("user");
 
      if (redirectToHome)
        this.router.navigate(['login']);
        
      return Observable.of(false);
    });
  }
}