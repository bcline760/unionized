import { Injectable, Inject } from '@angular/core';
import { LOCAL_STORAGE, StorageService } from 'ngx-webstorage-service';

import { environment } from '../../environments/environment';
import { HttpService } from './http.service';
import { UnionizedService } from './unionized.service';
import { MonitoredServer } from '../model/monitored-server';
@Injectable({
  providedIn: 'root'
})
export class ServerService extends UnionizedService {

  private apiController: string = "server";
  constructor(protected http: HttpService, @Inject(LOCAL_STORAGE) public storage: StorageService) {
    super(http, storage);
  }

  public async checkAllServers(): Promise<MonitoredServer[]> {
    const url: string = `${environment.apiUrl}/${this.apiController}/check`;

    const response:any = await this.http.getAsync(url, this.authenticationToken);

    if (response.success) {
      let servers:MonitoredServer[] = response.data;

      return servers;
    }
    
    return [];
  }
}
