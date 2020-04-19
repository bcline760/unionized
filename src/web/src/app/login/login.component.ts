import { Component, OnInit } from '@angular/core';
import { LoginModel } from './login.model';
import { SessionService } from '../service/session.service';
import { Router, ActivatedRoute } from '@angular/router';
import { LoadingService } from '../service/loading.service';
import { LoginResponse } from '../model/login-response';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    public model: LoginModel;
    public hasFailed: boolean = false;
    private returnUrl: string;

    constructor(
        protected session: SessionService,
        protected router: Router,
        protected loading: LoadingService,
        protected route: ActivatedRoute) {
        this.model = new LoginModel(session);
    }

    async ngOnInit(): Promise<void> {
        this.route.params.pipe()
    }

    async onLogin(): Promise<void> {
        const returnUrl: string = this.returnUrl == null ? '' : this.returnUrl;

        try {
            this.loading.show();
            const response: LoginResponse = await this.session.authenticateAsync(
                this.model.username,
                this.model.password,
                this.model.remember
            );
            this.loading.hide();
            if (response.status == 0) {
                this.router.navigate([returnUrl]);
            } else {
                this.hasFailed = true;
            }
        } catch (e) {
            this.hasFailed = true;
        }
    }
}
