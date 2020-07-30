import { Injectable } from '@angular/core';
import { AppService } from './app.service';
import { HttpClientService } from './http-client.service';
import { NetworkLogModel } from '../model/network-log.model';
import { ApiResponse } from '../model/api-response.model';

@Injectable({
  providedIn: 'root'
})
export class NetworkService extends AppService {

  constructor(protected httpService: HttpClientService) {
    super(httpService);
  }

  // async getLogsByDateAsync(after: Date | null, before: Date | null):Promise<NetworkLog[]> {
  // }

  /**
   * Get network logs by port number. Must provide one or the other.
   * @param sourcePort The source port to search. Provide null to omit
   * @param destinationPort The destination port number to search. Provide null to omit
   */
  async getLogsByPort(sourcePort: number | null, destinationPort: number | null): Promise<NetworkLogModel[] | null> {
    let url: string = "/networklog/";

    if (sourcePort === null && destinationPort === null) {
      throw new Error('Please provide one of the source port or destination port');
    }

    if (sourcePort !== null) {
      url += `srcprt/${sourcePort}`;
    } else if (destinationPort !== null) {
      url += `dstprt/${destinationPort}`;
    }

    const response = await this.httpService.getAsync<ApiResponse<NetworkLogModel[]>>(url);

    if (response.success) {
      return response.data;
    }

    return null;
  }
}
