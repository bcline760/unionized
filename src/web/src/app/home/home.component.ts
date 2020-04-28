import { Component, OnInit, OnDestroy } from '@angular/core';
import { WeatherService } from '../service/weather.service'
import { LoadingService } from '../service/loading.service';
import { HomeModel } from './home-model';
import { ServerService } from '../service/server.service';
import { Subject } from 'rxjs';
import { MonitoredServer } from '../model/monitored-server';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
    public model: HomeModel;
    public dtOptions: DataTables.Settings = {};
    public dtTrigger: Subject<MonitoredServer> = new Subject();

    constructor(
        public weather: WeatherService,
        protected loadingSvc: LoadingService,
        protected serverSvc: ServerService) {
        this.model = new HomeModel();
    }

    async ngOnInit(): Promise<void> {
        this.loadingSvc.show();
        // this.model.weather = this.weather.getCurrentConditions(92101);

        this.dtOptions = {
            search: false,
            searching: false,
            paging: false,
            processing: true,
            info: false,
            language: {
                emptyTable: "Wait for it...",
                zeroRecords: "Nothing..."
            }
        };

        this.model.servers = await this.serverSvc.checkAllServers();
        this.dtTrigger.next();
        this.loadingSvc.hide();
    }

    ngOnDestroy(): void {
        this.dtTrigger.unsubscribe();

    }
}
