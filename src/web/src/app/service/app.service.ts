import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { AuthToken } from '../model/auth-token.model';

@Injectable({
    providedIn: 'root'
})
export abstract class AppService {
    constructor(
        protected httpService: HttpClientService
    ) { }

    protected authToken: AuthToken;

    protected handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
            console.error('An error has occured:', error.message);
        } else {
            console.error('API server returned', error.status);
        }

        return throwError('An error has occured within the application');
    }
}
