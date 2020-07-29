import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Login } from './login.model';
import { SessionService } from 'src/app/service/session.service';
import { LoadingService } from 'src/app/service/loading.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {
  public model: Login | null = null;
  public redirectRoute: string | null = null;

  constructor(private session: SessionService,
    private loading: LoadingService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    if (this.model === null) {
      this.model = new Login();
      this.model.valid = true;
    }
  }

  ngOnDestroy(): void {

  }

  ngOnInit(): void {
    this.activatedRoute.queryParams.subscribe(s => {
      if (s['redirect'] !== null) {
        this.redirectRoute = s['redirect'];
      }
    });
  }

  async loginAsync(): Promise<void> {
    if (this.model !== null) {
      this.model.valid = true;
      this.loading.show('Logging In...');
      const result = await this.session.authenticateAsync(this.model.logonRequest);
      this.loading.hide();
      if (result) {
        if (this.redirectRoute !== null) {
          this.router.navigateByUrl(this.redirectRoute);
        } else {
          this.router.navigate(['home', '']);
        }
      } else {
        this.model.logonRequest.username = null;
        this.model.logonRequest.password = null;
        this.model.valid = false;
      }
    }
  }
}
