import { Component, OnInit } from '@angular/core';
import { SessionService } from 'src/app/service/session.service';
import { Router } from '@angular/router';
import { LoadingService } from 'src/app/service/loading.service';

@Component({
  selector: 'app-site-layout',
  templateUrl: './site-layout.component.html',
  styleUrls: ['./site-layout.component.css']
})
export class SiteLayoutComponent implements OnInit {

  constructor(
    protected session: SessionService,
    protected loading: LoadingService,
    protected router: Router) { }

  ngOnInit() {
  }

  async signOut(): Promise<void> {
    this.loading.show();
    await this.session.logoutAsync();
    this.loading.hide();
    this.router.navigate(['login']);
  }
}
