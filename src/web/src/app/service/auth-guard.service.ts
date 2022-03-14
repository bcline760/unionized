import { UrlTree, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { AppService } from './app.service';
import { HttpClientService } from './http-client.service';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { SessionService } from './session.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService extends AppService implements CanActivate {

  constructor(public session: SessionService,
    protected router: Router,
    protected httpService: HttpClientService,
    protected jwtService: JwtHelperService) {
    super(httpService);
  }

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean | UrlTree> {
    if (this.jwtService.isTokenExpired()) {
      return this.router.parseUrl('session/login');
    }

    const token = this.jwtService.decodeToken();

    return true;
  }
}
