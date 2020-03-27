import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../../service/weather.service';
import { HomeModel } from './home-model';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    private model: HomeModel;
    constructor(public weather: WeatherService) {
        this.model = new HomeModel();
    }

    ngOnInit() {
        this.model.weather = this.weather.getCurrentConditions(92101);
    }
}
