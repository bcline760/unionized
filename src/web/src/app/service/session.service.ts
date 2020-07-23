import { Injectable } from '@angular/core';
import { AppService } from './app.service';
import { HttpClientService } from './http-client.service';
import { LoginRequest } from '../model/login-request';
import { environment } from 'src/environments/environment';
import { throwError } from 'rxjs';
import { LoginResponse } from '../model/login-response';

@Injectable({
  providedIn: 'root'
})
export class SessionService extends AppService {

  constructor(protected httpService: HttpClientService) {
    super(httpService);
  }

  async authenticateAsync(request: LoginRequest): Promise<boolean> {
    const url = `${environment.apiUrl}/session/login`;

    try {
      const response: LoginResponse = await this.httpService.postAsync<LoginResponse, LoginRequest>(url, request);

      if (response.status == 0) {
        this.authToken = {
          loginToken: response.logonToken,
          username: request.Username
        };
        return true;
      }
    } catch (e) {
      console.log(e);
      throwError('authenticateAsync');
    }

    return false;
  }

  async signoutAsync(username: string, token: string): Promise<any> {
    const url = `${environment.apiUrl}/session/logout`;

    try {
      const result = await this.httpService.getAsync(url, this.authToken.loginToken);
    } catch (e) {
      console.log(e);
      throwError('signoutAsync');
    }
  }

  async validateTokenAsync(username: string, token: string): Promise<boolean> {
    const url = `${environment.apiUrl}/session/validate`;

    let valid: boolean = false;
    try {
      await this.httpService.getAsync(url, this.authToken.loginToken);

      valid = true;
    } catch (e) {
      console.log(e);
      throwError('validateTokenAsync');
      valid = false;
    }

    return valid;
  }
}
