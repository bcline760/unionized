import { Injectable } from '@angular/core';
import {
    CanActivate,
    ActivatedRouteSnapshot,
    RouterStateSnapshot,
    Router,
} from '@angular/router';
import { SessionService } from './session.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {
    constructor(public session:SessionService, public router:Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        const expectedRole = route.data.expectedRole;

        const canNavigate: boolean = this.session.validateToken(expectedRole);
        if (canNavigate)
            return true;
        else {
            this.router.navigate(['login']);
            return false;
        }
    }
}