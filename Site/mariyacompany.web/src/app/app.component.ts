import { Component } from '@angular/core';
import * as $ from "jquery";

import { EmployeeService } from './employee.service';
import { Employee } from './models/employee';
import { Department } from './models/departments';
import { CompanyPositions } from './models/company.positions';
import { UpdateEmployee } from './models/updateemployee';
import { Filter } from './models/filter';
import { SortModel } from './models/sortmodel';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css', '../../assets/css/bootstrap.min.css'],
  providers: [EmployeeService]
})

export class AppComponent {
  employee: Employee = new Employee();
  employees: Employee[] = [];
  departments: Department[] = [];
  companyPositions: CompanyPositions[] = [];
  emptyEmployee: boolean = true;
  filterEmpl: Filter = new Filter();
  sortModel: SortModel[] = [];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.loadDepartments();
    this.loadCompanyPositions();
    this.loadEmployees();
    this.loadSortModel();
  }

  loadSortModel() {
    this.sortModel.push(new SortModel(1, "Отдел", 400, true, true));
    this.sortModel.push(new SortModel(2, "Ф.И.О", 400, false, true));
    this.sortModel.push(new SortModel(3, "Дата рождения", 300, false, true));
    this.sortModel.push(new SortModel(4, "Дата трудоустройства", 400, false, true));
    this.sortModel.push(new SortModel(5, "Должность", 400, false, true));
  }

  selectSort(sortModel: SortModel) {
    if (sortModel.isAsc) {
      sortModel.isAsc = false;
    }
    else {
      sortModel.isAsc = true;
    }

    for (var i = 0; i < this.sortModel.length; i++) {
      if (this.sortModel[i].id == sortModel.id) {
        this.sortModel[i].isAsc = sortModel.isAsc;
        this.sortModel[i].isActive = true;

        this.filterEmpl.isAsc = sortModel.isAsc;
        this.filterEmpl.sortType = sortModel.id;
        this.loadEmployees();
      }
      else {
        this.sortModel[i].isActive = false;
      }
    }
  }

  loadEmployees() {
    this.employeeService.getEmployees(this.filterEmpl)
      .subscribe((data: Employee[]) => {
        this.employees = data;
        if (this.employees.length > 0) {
          this.emptyEmployee = false;
        }
        for (var i = 0; i < this.employees.length; i++) {
          this.employees[i].departmentString = this.getName(this.employees[i].departmentId, CategoryEnum.Department);
          this.employees[i].companyPositionString = this.getName(this.employees[i].companyPositionId, CategoryEnum.СompanyPosition);

          this.employees[i].birthdayString = this.getDateString(this.employees[i].birthday);
          this.employees[i].employmentDateString = this.getDateString(this.employees[i].employmentDate);
        }
      });
  }

  loadDepartments() {
    this.employeeService.getDepartments()
      .subscribe((data: Department[]) => {
        this.departments = data;
      });
  }

  loadCompanyPositions() {
    this.employeeService.getCompanyPositions()
      .subscribe((data: CompanyPositions[]) => {
        this.companyPositions = data;
      });
  }

  update() {
    this.employeeService.updateEmployee(new UpdateEmployee(this.employee.id, this.employee.firstName, this.employee.middleName,
      this.employee.lastName, this.employee.birthday, this.employee.employmentDate, Number(this.employee.departmentId), Number(this.employee.companyPositionId)))
      .subscribe(data => {
        if (data.isSuccess) {
          this.loadEmployees();
          this.closemodal('#updateModal');
        }
      });
    this.cancel();
  }

  createemployee() {
    this.employeeService.createEmployee(new UpdateEmployee(0, this.employee.firstName, this.employee.middleName,
      this.employee.lastName, this.employee.birthday, this.employee.employmentDate, Number(this.employee.departmentId), Number(this.employee.companyPositionId)))
      .subscribe(data => {
        if (data.isSuccess) {
          this.loadEmployees();
          this.closemodal('#createModal');
        }
      });
  }

  editEmployee(p: Employee) {
    this.employee = p;
    this.openmodal("#updateModal");
  }
  cancel() {
    this.employee = new Employee();
  }
  delete(p: Employee) {
    if (p.id != null) {
      this.employeeService.deleteEmployee(p.id)
        .subscribe(data => this.loadEmployees());
    }
  }

  add() {
    this.cancel();
  }

  createOpenModal() {
    this.employee = new Employee;
    this.openmodal("#createModal");
  }

  openmodal(modalName: string) {
    $(modalName).show();
    $('#overlay').removeAttr('hidden');
  }

  closemodal(modalName: string) {
    $(modalName).hide();
    $('#overlay').prop('hidden', true);
  }

  getName(id?: number, type?: CategoryEnum) {
    switch (type) {
      // @ts-ignore
      case CategoryEnum.Department:
        for (var i = 0; i < this.departments.length; i++) {
          if (this.departments[i].id == id) {
            return this.departments[i].name;
          }
        }
      case CategoryEnum.СompanyPosition:
        for (var i = 0; i < this.companyPositions.length; i++) {
          if (this.companyPositions[i].id == id) {
            return this.companyPositions[i].name;
          }
        }
    }

    return type == CategoryEnum.Department ? type + " не определена" : type == CategoryEnum.СompanyPosition ? type + " не определено" : "Значение не определено";
  }

  getDateString(dt?: Date) {
    if (dt == null) {
      return "";
    }

    var date = new Date(dt);
    var dateString = date.getDay() + '/' + date.getMonth() + '/' + date.getFullYear();
    return dateString;
  }

  openContent(contentName: string) {
    var contents = document.getElementsByClassName('content');
    for (var i = 0; i < contents.length; i++) {
      var id = '#' + contents[i].id;
      $(id).prop('hidden', true);
    }

    $(contentName).removeAttr('hidden');
  }

  title = 'angularapp';
}

enum CategoryEnum {
  Department = "Должность",
  СompanyPosition = "Название отдела",
}
