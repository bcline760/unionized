import { Component, OnInit } from '@angular/core';
import { SessionService } from '../service/session.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-signout',
  templateUrl: './signout.component.html',
  styleUrls: ['./signout.component.scss']
})
export class SignoutComponent implements OnInit {
  showError: boolean = false;
  errorText: string = '';

  constructor(
    protected service: SessionService,
    protected router: Router,
    protected route: ActivatedRoute) { }

  async ngOnInit(): Promise<void> {
    await this.service.logoutAsync();
    this.router.navigate(['/']);
  }
}
