export class LoginRequest {
  public username: string | null;
  public password: string | null;
  public persist: boolean;
  public ssoToken: string | null;

  constructor() {
    this.username = null;
    this.password = null;
    this.persist = false;
    this.ssoToken = null;
  }
}
