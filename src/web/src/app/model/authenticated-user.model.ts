export class AuthenticatedUser {
  public authenticated: boolean;
  public email: string | null;
  public fullName: string | null;
  public role: number;
  public token: string | null;

  constructor() {
    this.authenticated = false;
    this.email = null;
    this.fullName = null;

    this.role = 0;
    this.token = null;
  }
}
