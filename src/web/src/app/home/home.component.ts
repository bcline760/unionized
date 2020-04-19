import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../service/weather.service'
import { HomeModel } from './home-model';
import { LoadingService } from '../service/loading.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
    public model: HomeModel;
    constructor(
        public weather: WeatherService,
        protected loadingSvc:LoadingService) {
        this.model = new HomeModel();
    }

    ngOnInit() {
        this.loadingSvc.show();
        // this.model.weather = this.weather.getCurrentConditions(92101);
        this.loadingSvc.hide();
    }
}
