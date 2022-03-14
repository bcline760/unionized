import { Component, OnInit } from '@angular/core';
import { SessionService } from 'src/app/service/session.service';
import { Header } from './header.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  constructor(private session: SessionService) {
    this.model = new Header();
  }

  ngOnInit(): void {
    const user = this.session.readToken();

    if (user !== null) {
      this.model.authenticatedEmail = user.email;
      this.model.authenticatedName = user.fullName;
    }
  }

  public model: Header;
}
