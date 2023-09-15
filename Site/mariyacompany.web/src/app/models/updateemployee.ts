export class UpdateEmployee {
  constructor(
    public id?: number,
    public firstName?: string,
    public middleName?: string,
    public lastName?: string,
    public birthday?: Date,
    public employmentDate?: Date,
    public departmentId?: number,
    public companyPositionId?: number) { }
}
