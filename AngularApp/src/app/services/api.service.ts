import { Injectable } from '@angular/core';
import { HttpModule, Http, RequestOptions, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import { environment } from '../../environments/environment';
import { User } from '../models/user';


@Injectable()
export class ApiService {
  URL:string;
 
  constructor(public http:Http) { 
    if (environment.production)
      this.URL = "http://localhost:11379/api/";
    else
      this.URL = "http://localhost:11379/api/";
    
  }

  httpGet(url:string){
    return this.http.get(this.URL + url);
      //.map(result => result.json());
  }
 
  httpAuthorizedGet(url:string, user:User){ 
    let authHeaders = new Headers({'Content-Type': 'application/json'}); 
    if (user != null)
      authHeaders.append('Authorization', user.token_type + " " + user.access_token);
 
    let options = new RequestOptions({headers: authHeaders});
 
    return this.http.get(this.URL + url, options);
  }

  httpPostUrlEncoded(url:string, data:any){
    return this.http.post(this.URL + url, data); 
  }
 
  httpPostJson(url:string, data:any){
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({headers: headers});
 
    return this.http.post(this.URL + url, data, options); 
  }
 
}