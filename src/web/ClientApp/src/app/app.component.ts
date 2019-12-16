import { Component, OnInit } from '@angular/core';
import { SessionService } from '../service/session.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'Unionized!';

    public authenticated: boolean = false;
    
    constructor(public session: SessionService) {

    }

    ngOnInit(): void {
    }
}
