import { Component, OnInit } from '@angular/core';
import { LoginModel } from './login.model';
import { SessionService } from 'src/service/session.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    protected model: LoginModel;
    private hasFailed: boolean = false;
    constructor(protected session: SessionService) {
        this.model = new LoginModel(session);
    }

    ngOnInit() {
    }

    onLogin(): void {
        try {
            this.session.authenticateAsync(this.model.username, this.model.password, this.model.remember).subscribe(s => {
                if (s.Status == 0) {

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
