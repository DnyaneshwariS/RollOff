import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
//import{GetAllEmployeeResponse} from '../Models/api-models/getallstudentresponse.models'
import {Employee} from '../Models/api-models/Employee.models';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailsService {

  baseApiUrl:string=environment.baseApiUrl;
  constructor(private httpClient:HttpClient) { }

  getEmployee():Observable<Employee[]>{
    return this.httpClient.get<Employee[]>(this.baseApiUrl+'Employees/GetDetails');
  }

  getEmployeebyid(employeeid: string|null):Observable<Employee> {
    return this.httpClient.get<Employee>(this.baseApiUrl+'Employees/GetEmployeeByID?id='+employeeid);
  }

  //baseServerUrl=environment.baseApiUrl+ 'api/';
  registerUser(reg:any){
    return this.httpClient.post(this.baseApiUrl+"api/User/CreateUser",{
      Name:reg[0],
      Email:reg[0],
      Password:reg[0],
      Role:reg[0]
    },

      
    {

    responseType:'text',
    });
  }
  }


