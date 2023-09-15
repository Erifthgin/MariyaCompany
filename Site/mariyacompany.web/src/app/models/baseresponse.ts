export class BaseResponse {
  constructor(
    public isSuccess?: boolean,
    public errorMessage?: string) { }
}
