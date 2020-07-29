import { Component, OnInit } from '@angular/core';
import { faHome, faNetworkWired, faCertificate, faSignOutAlt, faMobile, IconDefinition } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public faHome: IconDefinition = faHome;
  public faNetworkWired: IconDefinition = faNetworkWired;
  public faCertificate: IconDefinition = faCertificate;
  public faSignOut: IconDefinition = faSignOutAlt;
  public faMobile: IconDefinition = faMobile;
}
