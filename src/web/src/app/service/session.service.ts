import { Injectable } from '@angular/core';
import { AppService } from './app.service';
import { HttpClientService } from './http-client.service';
import { LoginRequest } from '../model/login-request';
import { environment } from 'src/environments/environment';
import { throwError } from 'rxjs';
import { LoginResponse } from '../model/login-response';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthenticatedUser } from '../model/authenticated-user.model';

@Injectable({
  providedIn: 'root'
})
export class SessionService extends AppService {

  constructor(
    protected httpService: HttpClientService,
    protected jwtService: JwtHelperService) {
    super(httpService);
  }

  async authenticateAsync(request: LoginRequest): Promise<boolean> {
    const url = `/session/login`;

    try {
      const response: LoginResponse = await this.httpService.postAsync<LoginResponse, LoginRequest>(url, request);

      if (response.status == 0) {
        localStorage.setItem('access_token', response.logonToken);
        return true;
      }
    } catch (e) {
      console.log(e);
      throwError('authenticateAsync');
    }

    return false;
  }

  readToken(): AuthenticatedUser | null {
    if (this.jwtService.isTokenExpired()) {
      return null;
    }

    const token = this.jwtService.decodeToken();
    const user: AuthenticatedUser = new AuthenticatedUser();
    user.authenticated = true;
    user.email = token.email;
    user.fullName = token.unique_name;

    return user;
  }

  async signoutAsync(): Promise<any> {
    const url = `/session/logout`;

    try {
      const result = await this.httpService.getAsync(url);
    } catch (e) {
      console.log(e);
      throwError('signoutAsync');
    }
  }

  async validateTokenAsync(username: string, token: string): Promise<boolean> {
    const url = `/session/validate`;

    let valid: boolean = false;
    try {
      await this.httpService.getAsync(url);

      valid = true;
    } catch (e) {
      console.log(e);
      throwError('validateTokenAsync');
      valid = false;
    }

    return valid;
  }
}
