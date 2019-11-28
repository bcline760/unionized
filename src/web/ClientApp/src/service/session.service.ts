import { Injectable, Inject } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';
import { LoginRequest } from 'src/interfaces/login-request';
import { LoginResponse } from 'src/interfaces/login-response';
import { tap, catchError } from 'rxjs/operators';
import { environment } from '../environments/environment';
import { HttpService } from './http.service';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class SessionService {
    private apiController: string = "session";

    constructor(public http: HttpService, @Inject(LOCAL_STORAGE) public storage: StorageService) {
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
            if (res.Status == 0) {
                this.storage.set(environment.tokenStorageKey, res.LoginToken);
            }
        }),
            catchError(this.handleError)
        );
        return response;
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
