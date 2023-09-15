export class Filter {
  constructor(
    public surname?: string,
    public ageTo?: number,
    public ageFrom?: number,
    public departmentId?: number,
    public companyPositionId?: number,
    public isAsc?: boolean,
    public sortType?: number) { }
}
