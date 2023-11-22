import { department } from './../Models/department';
import { Component } from '@angular/core';
import { ApiserviceService } from '../service/apiservice.service';
import { Employee } from '../Models/Employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent {
employeeArray : Array<any> = [];
departmentArray : Array<any> = [];

emp:Employee={
  Name:"",
  department:"",
  Doj:""
}

  constructor(private apiService : ApiserviceService ){
this.getUser();
this.getEmployee();
  }

  getUser(){
    this.apiService.getDepartmentList().subscribe((data)=>{
      this.departmentArray=data;
      console.log(this.departmentArray);
    })
  }

  getEmployee(){
    this.apiService.getEmployee().subscribe((data)=>{
      console.log(data);
      this.employeeArray=data;
    })
  }
  num! : number;
  Empl(i:number){
    this.num=i;
  }

  removeEmployee(i:number){    
    this.apiService.removeEmployeeService(i).subscribe((data)=>{
      console.log(data);
      this.getEmployee();
      
    })
  }
  addEmployee(){
    console.log(this.emp.Name);
    console.log(this.emp.department);
    console.log(this.emp.Doj);
    this.apiService.addemployeeService(this.emp).subscribe((data)=>{
      console.log(data);
      this.getEmployee();
      this.emp.Name="";
      this.emp.Doj="";
      this.emp.department="";
    });
  }

  EditEmployee(){
    this.apiService.editEmployeeService(this.num,this.emp).subscribe((data)=>{
      console.log(data);
      this.getEmployee();
      this.emp.Name="";
      this.emp.department="";
      this.emp.Doj="";
    })
  }
}
