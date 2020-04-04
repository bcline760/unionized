import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../weather.service'
import { HomeModel } from './home-model';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
    public model: HomeModel;
    constructor(public weather: WeatherService) {
        this.model = new HomeModel();
    }

    ngOnInit() {
        this.model.weather = this.weather.getCurrentConditions(92101);
    }
}
