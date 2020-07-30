import { Component, OnInit } from '@angular/core';
import { HomeModel } from './home.model';
import { ServerService } from '../service/server.service';
import { NetworkService } from '../service/network.service';
import { LoadingService } from '../service/loading.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private serverSvc: ServerService,
    private loadingSvc: LoadingService,
    private networkSvc: NetworkService) {
    this.model = new HomeModel();
  }

  async ngOnInit(): Promise<void> {
    this.loadingSvc.show("Getting servers...");
    const servers = await this.serverSvc.checkServersAsync();
    if (servers !== null && servers.success) {
      if (this.model !== null) {
        this.model.serverList = servers.data;
      }
    }
    this.loadingSvc.hide();
  }

  public model: HomeModel;
}
