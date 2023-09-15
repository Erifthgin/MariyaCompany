export class CreateEmployeeResponse {
  constructor(
    public isSuccess?: boolean,
    public errorMessage?: string,
    public employeeId?: number) { }
}
