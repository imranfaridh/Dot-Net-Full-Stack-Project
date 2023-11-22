import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { department } from '../Models/department';
import { Employee } from '../Models/Employee';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {

  baseApi : string = "https://localhost:7290/api";

  constructor(private http:HttpClient) { }

  getDepartmentList(){
    return this.http.get<any>(`${this.baseApi}/department/getAll`)
  }

  
   
  edit(i:number, dept:department){
      let putBody = {
        "departmentId" : i,
        "departmentName" : dept.name
      }
      return this.http.put(`${this.baseApi}/department/update/${i}`, putBody,{responseType : 'json'});
  }

  remove(i:number){
    return this.http.delete(`${this.baseApi}/department/delete/${i}`);
  }


  addDepartment(dept:any){
    let postBody ={
      "departmentName" : dept.name
    }
    return this.http.post<any>(`${this.baseApi}/department/save`, postBody, {responseType : 'json'});
  }


  //Employee

  getEmployee(){
    return this.http.get<any>(`${this.baseApi}/Employee/getAll`)
  }

  removeEmployeeService(i:number){
    return this.http.delete<any>(`${this.baseApi}/Employee/delete/${i}`, {responseType : 'json'})
  }

  addemployeeService(empl:Employee){
    let postEmpl={
     "employeeName": empl.Name ,
     "department": empl.department ,
     "doj": empl.Doj
   }
   return this.http.post<any>(`${this.baseApi}/Employee/save`,postEmpl,{responseType:'json'});
}

  editEmployeeService(i:number,emp:Employee){
    let putBody ={
      "employeeId" : i,
      "employeeName" : emp.Name,
      "department": emp.department,
      "doj":emp.Doj
    }
    return this.http.put<any>(`${this.baseApi}/Employee/update/${i}`, putBody, {responseType : 'json'})
  }
}

