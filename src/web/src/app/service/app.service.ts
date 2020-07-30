import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { AuthToken } from '../model/auth-token.model';

/**
 * Defines a template for services which interact with the backend API
 */
export abstract class AppService {

  constructor(protected httpService: HttpClientService) {

  }

  /**
   * Handles an HTTP response error like HTTP 500 or HTTP 401
   * @param error The HTTP response error generated
   */
  protected handleError(error: HttpErrorResponse): void {
    if (error.error instanceof ErrorEvent) {
      console.error('An error has occured:', error.message);
      throwError('An error has occured within the application');
    } else {
      console.error('API server returned', error.status);
    }
  }
}
