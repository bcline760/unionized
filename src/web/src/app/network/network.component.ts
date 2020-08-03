import { Component, OnInit, OnDestroy } from '@angular/core';
import { NetworkService } from '../service/network.service';
import { NetworkPage } from './networkpage.model';
import { NetworkLogModel } from '../model/network-log.model';
import { LoadingService } from '../service/loading.service';
import { Subject } from 'rxjs';
import { ApiResponse } from '../model/api-response.model';

@Component({
  selector: 'app-network',
  templateUrl: './network.component.html',
  styleUrls: ['./network.component.scss']
})
export class NetworkComponent implements OnInit, OnDestroy {

  constructor(private service: NetworkService, private loading: LoadingService) {
    this.model = new NetworkPage();
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  async ngOnInit(): Promise<void> {
    const now: Date = new Date(Date.now());

    const that = this;

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      responsive: true,
      autoWidth: true,
      lengthChange: false,
      columns: [
        { data: 'logDate' },
        { data: 'sourceAddress' },
        { data: 'destinationAddress' },
        { data: 'sourcePort' },
        { data: 'destinationPort' },
        { data: 'protocol' },
        { data: 'packetLength' },
        { data: 'tcpAction' }
      ]
    }

    that.loading.show('Getting logs...')
    const response: NetworkLogModel[] | null = await that.service.getLogsByDateAsync(undefined, now);
    that.loading.hide();

    if (response !== null) {
      this.model.logs = response;
      this.dtTrigger.next();
    }
  }

  public model: NetworkPage;
  public dtOptions: DataTables.Settings = {};
  public dtTrigger: Subject<any> = new Subject<any>();
}
