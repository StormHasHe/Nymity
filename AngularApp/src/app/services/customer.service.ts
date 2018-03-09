import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Constants } from '../constants';
import { User } from '../models/user';
 
@Injectable()
export class CustomerService {
 
  constructor(public api:ApiService, public constants:Constants) { }
 
  getCustomers(user:User){
    return this.api.httpAuthorizedGet(this.constants.GET_CUSTOMERS, user);
  }
 
  getCustomersById(customerID:string, user:User){
    return this.api.httpAuthorizedGet(this.constants.GET_CUSTOMERS + "/" + customerID, user);
  }
 
}