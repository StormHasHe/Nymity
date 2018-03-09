import { Component, OnInit } from '@angular/core';
import { User } from './models/user';
import { LoginService } from './services/login.service';
import { AuthGuardService } from './services/auth-guard.service';
 
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [LoginService, AuthGuardService]
})

export class AppComponent implements OnInit {
  isAuthenticated:boolean
  username:string
 
  constructor(private loginService:LoginService, private authGuard:AuthGuardService){
    loginService.onLogin$.subscribe(x => {
      this.authGuard.userAuthenticated(false).subscribe(authenticated => {
        if (authenticated){
          let user = <User>JSON.parse(localStorage.getItem("user"));
          this.isAuthenticated = authenticated;
          this.username = user.username;
        }     
      });
    });
  }
  
  ngOnInit() {
    this.authGuard.userAuthenticated(false).subscribe(authenticated => {
      if (authenticated){
        let user = <User>JSON.parse(localStorage.getItem("user"));
        this.isAuthenticated = authenticated;
        this.username = user.username;
      } 
    });
  }
 
  logOut()
  {
    localStorage.removeItem("user");
  }
}
 