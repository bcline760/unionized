import { Injectable, Inject } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, throwError } from 'rxjs';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';
import { environment } from '../../environments/environment';
import { HttpService } from './http.service';

import { LoginRequest } from '../model/login-request';
import { LoginResponse } from '../model/login-response';
import { UnionizedService } from './unionized.service';

@Injectable()
export class SessionService extends UnionizedService {
    private apiController: string = "session";

    constructor(
        protected http: HttpService,
        @Inject(LOCAL_STORAGE) public storage: StorageService,
        private jwtService: JwtHelperService) {
        super(http, storage);
    }

    async authenticateAsync(username: string, password: string, persist: boolean) {
        let request: LoginRequest = {
            Username: username,
            Password: password,
            Persist: persist,
            SsoToken: ""
        };

        const url: string = `${environment.apiUrl}/${this.apiController}/login`;
        let response: LoginResponse = {
            logonToken: '',
            status: 1
        };

        try {
            response = await this.http.sendAsync<LoginResponse, LoginRequest>(url, request, "POST");

            if (response.status == 0) {
                this.storage.set(environment.tokenStorageKey,response.logonToken);
            }
        } catch (e) {
            console.log(e);
            throwError('authenticateAsync');
        }

        return response;
    }

    async logoutAsync(username: string): Promise<any> {
        const url: string = `${environment.apiUrl}/${this.apiController}/logout`;
        const authToken: string = this.storage.get(environment.tokenStorageKey);
        const logoutRequest = {
            username: username,
            token: authToken
        };

        try {
            const response = await this.http.sendAsync<any,any>(url,logoutRequest,"POST");

            return response;
        } catch (e) {
            console.log(e);
            throwError('logoutAsync');
        }
    }

    async validateTokenAsync(expectedRole: string) {
        let valid: boolean = true;

        try {
            if (this.authenticationToken != undefined) {
                const url: string = `${environment.apiUrl}/${this.apiController}/validate`;
                await this.http.getAsync<boolean>(url, this.authenticationToken);
            }
        } catch (e) {
            console.log(e);
            //throwError('Error with validateTokenAsync');
            valid = false;
        }

        return valid;
    }
}
