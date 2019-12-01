import { Injectable, Inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { Observable, throwError } from 'rxjs';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';
import { tap, catchError, shareReplay } from 'rxjs/operators';

import { LoginRequest } from 'src/interfaces/login-request';
import { LoginResponse } from 'src/interfaces/login-response';
import { environment } from '../environments/environment';
import { HttpService } from './http.service';


@Injectable()
export class SessionService {
    private apiController: string = "session";

    constructor(
        public http: HttpService,
        @Inject(LOCAL_STORAGE) public storage: StorageService,
        public jwtService: JwtHelperService) {
    }

    authenticateAsync(username: string, password: string, persist: boolean): Observable<LoginResponse> {
        let request: LoginRequest = {
            Username: username,
            Password: password,
            Persist: persist,
            SsoToken: null
        };

        const url: string = `${environment.apiUrl}/${this.apiController}/login`;
        let response: Observable<LoginResponse> = this.http.send<LoginResponse, LoginRequest>(url, request, "POST").pipe(tap(res => {
            if (res.status == 0) {
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

        //const expiryDate: Date = this.jwtService.getTokenExpirationDate(authToken);
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

    protected handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(
                `Backend returned code ${error.status}, ` +
                `body was: ${error.error}`);
        }
        // return an observable with a user-facing error message
        return throwError(
            'Something bad happened; please try again later.');
    };
}
