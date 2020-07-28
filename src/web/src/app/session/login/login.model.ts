import { LoginRequest } from 'src/app/model/login-request';

export class Login {
  constructor() {
    this.valid = false;
    this.logonRequest = new LoginRequest();
  }

  public valid: boolean;

  public logonRequest: LoginRequest
}
