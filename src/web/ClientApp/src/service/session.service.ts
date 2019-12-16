import { Injectable, Inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { Observable, throwError } from 'rxjs';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';
import { tap, catchError, shareReplay } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { HttpService } from './http.service';
import { LoadingService } from './loading.service';

import { LoginRequest } from 'src/interfaces/login-request';
import { LoginResponse } from 'src/interfaces/login-response';
import { UnionizedService } from './unionized.service';

@Injectable()
export class SessionService extends UnionizedService {
    private apiController: string = "session";

    constructor(
        protected http: HttpService,
        @Inject(LOCAL_STORAGE) public storage: StorageService,
        protected loadingSvc:LoadingService,
        private jwtService: JwtHelperService) {
        super(http, loadingSvc);
    }

    authenticateAsync(username: string, password: string, persist: boolean): Observable<LoginResponse> {
        let request: LoginRequest = {
            Username: username,
            Password: password,
            Persist: persist,
            SsoToken: null
        };

        const url: string = `${environment.apiUrl}/${this.apiController}/login`;
        this.loadingSvc.show();
        let response: Observable<LoginResponse> = this.http.send<LoginResponse, LoginRequest>(url, request, "POST").pipe(tap(res => {
            if (res.status == 0) {
                this.loadingSvc.hide();
                this.storage.set(environment.tokenStorageKey, res.logonToken);
            }
        }),
            catchError(this.handleError),
            shareReplay(1)
        );
        return response;
    }

    logoutAsync(username:string): void {
        const url: string = `${environment.apiUrl}/${this.apiController}/logout`;
        const authToken: string = this.storage.get(environment.tokenStorageKey);
        const logoutRequest = {
            username: username,
            token: authToken
        };

        this.http.send<any, any>(url, logoutRequest, "POST").pipe(tap(res => {
            //Clear the token from the storage
            this.storage.remove(environment.tokenStorageKey);
        }),
            catchError(this.handleError)
        );
    }

    validateToken(expectedRole: string): boolean {
        const authToken: string = this.storage.get(environment.tokenStorageKey);

        if (authToken === "undefined") {
            return false;
        }

        const isExpired: boolean = this.jwtService.isTokenExpired(authToken);
        if (isExpired) {
            this.storage.set(environment.tokenStorageKey, '');
            return false;
        }

        //if (expectedRole == undefined) {
        //    const tokenPayload = this.jwtService.decodeToken(authToken);
        //    return expectedRole === tokenPayload.role;
        //}
        return true;
    }
}
