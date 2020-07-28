import { Component, OnInit, OnDestroy } from '@angular/core';
import { LoginRequest } from 'src/app/model/login-request';
import { SessionService } from 'src/app/service/session.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Login } from './login.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {
  public model: Login | null = null;
  public redirectRoute: string | null = null;

  constructor(private session: SessionService, private router: Router, private activatedRoute: ActivatedRoute) {
    if (this.model === null) {
      this.model = new Login();
    }
  }

  ngOnDestroy(): void {

  }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(s=>{
      if (s['redirect'] !== null) {
        this.redirectRoute = s['redirect'];
      }
    });
  }

  async loginAsync(): Promise<void> {
    if (this.model !== null) {
      const result = await this.session.authenticateAsync(this.model.logonRequest);
      if (result) {
        if (this.redirectRoute !== null) {
          this.router.navigate([this.redirectRoute]);
        } else {
          this.router.navigate(['/home']);
        }
      }
    }
  }
}
