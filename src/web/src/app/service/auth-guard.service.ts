import { UrlTree, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { AppService } from './app.service';
import { HttpClientService } from './http-client.service';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { SessionService } from './session.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService extends AppService implements CanActivate {

  constructor(public session: SessionService, router: Router, httpService: HttpClientService) {
    super(httpService);
  }

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
    if (!this.authToken) {
      return false;
    }

    const valid: boolean = await this.session.validateTokenAsync(this.authToken.username, this.authToken.loginToken);

    return valid;
  }
}
