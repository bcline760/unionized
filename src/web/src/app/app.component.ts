import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public showFullLayout: boolean = true;
  constructor(private router: Router, private activatedRoute:ActivatedRoute) {

  }

  ngOnInit(): void {
    this.router.events.subscribe(ev=> {
      if (ev instanceof NavigationEnd) {
        if (this.activatedRoute.firstChild !== null) {
          this.showFullLayout = this.activatedRoute.firstChild.snapshot.data.showFullLayout !== false;
        }
      }
    })
  }

  title = 'unionized';
}
