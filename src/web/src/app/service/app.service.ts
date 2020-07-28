import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { AuthToken } from '../model/auth-token.model';

export abstract class AppService {

  constructor(protected httpService: HttpClientService) {

  }

  protected handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error('An error has occured:', error.message);
      throwError('An error has occured within the application');
    } else {
      console.error('API server returned', error.status);
    }
  }
}
