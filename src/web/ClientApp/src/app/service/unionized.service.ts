import { Injectable, Inject } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { HttpService } from './http.service';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';
import { environment } from '../../environments/environment';
import { AuthToken } from '../model/auth-token.model';

export abstract class UnionizedService {
    protected authenticationToken: AuthToken;
    constructor(protected http: HttpService, @Inject(LOCAL_STORAGE) protected storage: StorageService) {
        const authToken: AuthToken = this.storage.get(environment.tokenStorageKey);
        
        if (authToken != undefined) {
            this.authenticationToken = authToken;
        }
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
