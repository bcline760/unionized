export class AuthenticatedUser {
  public authenticated: boolean;
  public email: string | null;
  public firstName: string | null;
  public lastName: string | null;
  public role: number;
  public token: string | null;

  constructor() {
    this.authenticated = false;
    this.email = null;
    this.firstName = null;
    this.lastName = null;
    this.role = 0;
    this.token = null;
  }
}
