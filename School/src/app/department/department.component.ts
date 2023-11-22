import { department } from './../Models/department';
import { Component } from '@angular/core';
import { ApiserviceService } from '../service/apiservice.service';


@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent {

  myArray : Array<any> = [];

  depart:department={
    name:""
  }


constructor(private apiService: ApiserviceService){
 this.getUser();
}

num! : number;
updepart(i:any){
  this.num=i
  return this.num;
}

getUser(){
  this.apiService.getDepartmentList().subscribe((data)=>{
    this.myArray=data;
    console.log(this.myArray);
  })
}   

updateDepartment(){
  this.apiService.edit(this.num, this.depart).subscribe((data)=>{
    console.log(data);
    this.getUser();
    this.depart.name= "";
  })
}

removeDepartment(del:any){
  this.apiService.remove(del.departmentId).subscribe((data)=>{
    console.log(data);
    this.getUser();
  })
}

addUser(){
  this.apiService.addDepartment(this.depart).subscribe((data)=>{
    console.log(data);
    this.getUser();
    this.depart.name = "";
  })
}

}
