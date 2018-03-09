import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';
import { UserRegisterModel } from '../../models/userRegisterModel';
import { User } from '../../models/user';
import { Subscription }   from 'rxjs/Subscription';
import { Router } from '@angular/router';
 
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userRegisterModel: UserRegisterModel;
  userName:string;
  password:string;
  confirmPassword:string;
  loginInvalid:boolean;
  registerInvalid:boolean;
  isRegister:boolean;

  constructor(private loginService:LoginService, private router:Router) { }
  
  ngOnInit() {
    this.userName = "";
    this.password = "";
    this.confirmPassword = "";
    this.isRegister = false;
    this.registerInvalid = false;
    this.loginInvalid = false;
  }
 
  toggleRegister(){
    this.isRegister = !this.isRegister;
  }
 
  register(){
    if (this.isRegistrationValid()){
      this.registerInvalid = false;
 
      this.loginService.postRegister(this.userName, this.password, this.confirmPassword).subscribe((response) => {
        this.login();
      },(error) => {
        console.log(error);
        this.registerInvalid = true;
      });
    }
  }

  login(){
    if (this.isLoginValid()){
      this.loginInvalid = false;
 
      this.loginService.postLogin(this.userName, this.password).subscribe((response) => {
        console.log(response);
        
        let user = <User>JSON.parse(response["_body"]);
        user.username = this.userName;
 
        localStorage.setItem("user", JSON.stringify(user));
 
        this.loginService.onUserLogin();
        this.router.navigateByUrl("/");
      },(error) => {
        console.log(error);
        this.loginInvalid = true;
      });
    } 
    else{
      this.loginInvalid = true;
      return false;
    }
 
    return false;
  }
 
  isLoginValid(){
    return this.userName != "" && this.password != "";
  }
 
  isRegistrationValid(){
    return this.userName != "" && this.password != "" && this.confirmPassword != "";
  }
 
}