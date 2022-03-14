export class AuthToken {
  public loginToken: string | null;
  public username: string | null;

  constructor() {
    this.loginToken = null;
    this.username = null;
  }
}
