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

    async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Promise<boolean> {
        const expectedRole = route.data.expectedRole;

        const canNavigate: boolean = await this.session.validateTokenAsync(expectedRole)
        if (canNavigate)
            return true;
        else {
            this.router.navigate(['login']);
            return false;
        }
    }
}