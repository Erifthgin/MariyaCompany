import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Employee } from './models/employee';
import { environment } from './environment';
import { Department } from './models/departments';
import { CompanyPositions } from './models/company.positions';
import { CreateEmployeeResponse } from './models/createemployeeresponse';
import { BaseResponse } from './models/baseresponse';
import { UpdateEmployee } from './models/updateemployee';
import { Filter } from './models/filter';

@Injectable()
export class EmployeeService {

  private employeeUrl = environment.apiBaseUrl + '/employees';
  constructor(private http: HttpClient) { }

  getEmployees(filterEmpl: Filter) {
    let params = this.getFilterQuery(filterEmpl);

    return this.http.get<Employee[]>(this.employeeUrl + params);
  }

  createEmployee(employee: UpdateEmployee) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.post<CreateEmployeeResponse>(this.employeeUrl + '/create', JSON.stringify(employee), { headers: myHeaders });
  }

  updateEmployee(employee: UpdateEmployee) {
    const myHeaders = new HttpHeaders().set("Content-Type", "application/json");
    return this.http.put<BaseResponse>(this.employeeUrl + '/update', JSON.stringify(employee), { headers: myHeaders });
  }

  deleteEmployee(id: number) {
    return this.http.delete<BaseResponse>(this.employeeUrl + '/delete/' + id);
  }

  getDepartments() {
    return this.http.get<Department[]>(this.employeeUrl + '/departments');
  }

  getCompanyPositions() {
    return this.http.get<CompanyPositions[]>(this.employeeUrl + '/companypositions');
  }

  getFilterQuery(filterEmpl: Filter) {
    let array = new Array<string>;

    if (filterEmpl.ageFrom != undefined) {
      array.push("ageFrom=" + Number(filterEmpl.ageFrom));
      }

    if (filterEmpl.ageFrom != undefined) {
      array.push("ageTo=" + Number(filterEmpl.ageTo));
    }

    if (filterEmpl.surname != undefined) {
      array.push("surname=" + String(filterEmpl.surname));
    }

    if (filterEmpl.departmentId != undefined) {
      array.push("departmentId=" + Number(filterEmpl.departmentId));
    }

    if (filterEmpl.companyPositionId != undefined) {
      array.push("companyPositionId=" + Number(filterEmpl.companyPositionId));
    }

    if (filterEmpl.isAsc != undefined) {
      array.push("isAsc=" + Boolean(filterEmpl.isAsc));
    }

    if (filterEmpl.sortType != undefined) {
      array.push("sortType=" + Number(filterEmpl.sortType));
    }

    if (array.length > 0) {
      return "?" + array.join("&");
    }

    return "";
  }
}
