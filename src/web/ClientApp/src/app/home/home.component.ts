import { Component, OnInit, OnDestroy } from '@angular/core';
import { WeatherService } from '../service/weather.service'
import { LoadingService } from '../service/loading.service';
import { HomeModel } from './home-model';
import { ServerService } from '../service/server.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, OnDestroy {
    public model: HomeModel;
    public dtOptions: DataTables.Settings = {};

    constructor(
        public weather: WeatherService,
        protected loadingSvc: LoadingService,
        protected serverSvc: ServerService) {
        this.model = new HomeModel();
    }

    async ngOnInit(): Promise<void> {
        this.loadingSvc.show();
        // this.model.weather = this.weather.getCurrentConditions(92101);

        this.model.servers = await this.serverSvc.checkAllServers();
        this.loadingSvc.hide();
    }

    ngOnDestroy(): void {
    }
}
