import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { Customer } from '../../models/customer';
import { User } from '../../models/user';
import { ResponseDTO } from '../../models/responseDTO';
 
@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  customers:Customer[];
  filteredCustomers:Customer[];
  showMessage:boolean;
 
  constructor(private customerService:CustomerService) { }
 
  ngOnInit() {
    this.customers = [];
    this.filteredCustomers = [];
    this.showMessage = false;
    this.loadAllCustomers();
  }

  clearFilter(){
    this.filteredCustomers = [];
  }
 
  getCustomerById(id:string){
    var user = <User>JSON.parse(localStorage.getItem("user"));
    this.customerService.getCustomersById(id, user).subscribe(response =>{
      var responseDto = <ResponseDTO>JSON.parse(response["_body"]);
 
      if (responseDto.success && responseDto.value.length > 0)
      {
        let customer = <Customer>responseDto.value[0];
        let alreadyFiltered = this.filteredCustomers.filter(x => x.customerID == customer.customerID)[0]
        
        if (alreadyFiltered){
          var index = this.filteredCustomers.findIndex(x => x.customerID == customer.customerID);
          this.filteredCustomers.splice(index, 1);
        }
        else
          this.filteredCustomers.push(customer); 
      }
      else
        this.showMessage = true;
    });
  }
  
  loadAllCustomers(){
    var user = <User>JSON.parse(localStorage.getItem("user"));
    this.customerService.getCustomers(user).subscribe(response =>{
      var responseDto = <ResponseDTO>JSON.parse(response["_body"]);
 
      if (responseDto.success && responseDto.value.length > 0)
        this.customers = responseDto.value;
      else
        this.showMessage = true;
    });
  }
 
}