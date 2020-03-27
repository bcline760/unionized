import { Component, OnInit } from '@angular/core';
import { LoginModel } from './login.model';
import { SessionService } from 'src/service/session.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    protected model: LoginModel;
    private hasFailed: boolean = false;
    private returnUrl: string;

    constructor(protected session: SessionService, protected router: Router, protected route: ActivatedRoute) {
        this.model = new LoginModel(session);
    }

    ngOnInit() {
        this.route.params.pipe()
    }

    onLogin(): void {
        try {
            this.session.authenticateAsync(this.model.username, this.model.password, this.model.remember).subscribe(s => {
                if (s.status == 0) {
                    if (this.returnUrl == null) {
                        this.router.navigate(['']);
                    } else {
                        this.router.navigate([this.returnUrl]);
                    }
                } else {
                    this.hasFailed = true;
                }
            }, e => {
                    this.hasFailed = true;
            });
        }
        catch (ex) {
            this.hasFailed = true;
        }
    }
}
