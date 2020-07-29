export class Header {
  constructor() {
    this.authenticatedEmail = null;
    this.authenticatedName = null;
    this.authenticatedRole = 0;
  }

  public authenticatedName: string | null;
  public authenticatedEmail: string | null;
  public authenticatedRole: number;
}
