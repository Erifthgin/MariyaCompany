import { CompanyPositions } from "./company.positions";

export class Employee {
  constructor(
    public id?: number,
    public firstName?: string,
    public middleName?: string,
    public lastName?: string,
    public birthday?: Date,
    public employmentDate?: Date,
    public departmentId?: number,
    public companyPositionId?: number,
    public summary?: string,
    public departmentString?: string,
    public companyPositionString?: string,
    public birthdayString?: string,
    public employmentDateString?: string,
    public companyPosition?: CompanyPositions) { }
}
