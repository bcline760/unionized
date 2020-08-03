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

  // async getLogsByDateAsync(after: Date, before: Date):Promise<NetworkLog[]> {
  // }

  /**
   * Get network logs by port number. Must provide one or the other.
   * @param sourcePort The source port to search. Provide null to omit
   * @param destinationPort The destination port number to search. Provide null to omit
   */
  async getLogsByPort(sourcePort?: number, destinationPort?: number): Promise<NetworkLogModel[] | null> {
    let url: string = "/networklog/";

    if (sourcePort === null && destinationPort === null) {
      throw new Error('Please provide one of the source port or destination port');
    }

    if (sourcePort) {
      url += `srcprt/${sourcePort}`;
    } else if (destinationPort) {
      url += `dstprt/${destinationPort}`;
    }

    const response = await this.httpService.getAsync<ApiResponse<NetworkLogModel[]>>(url);

    if (response.success) {
      return response.data;
    }

    return null;
  }

  /**
   * Get logs by a date window
   * @param after Optional - Query logs after this given date
   * @param before Optional - query logs before this given date
   */
  async getLogsByDateAsync(after?: Date, before?: Date): Promise<NetworkLogModel[] | null> {
    if (after === null && before === null) {
      throw new Error('Please provide one or both dates');
    }

    let request: any = {
      after: after?.toISOString(),
      before: before?.toISOString()
    };

    let queryString = (obj: any) => {
      let str: string[] = [];
      for (let p in obj) {
        if (obj.hasOwnProperty(p) && obj[p]) {
          str.push(encodeURIComponent(p) + '=' + encodeURIComponent(obj[p]));
        }
      }
      return str.join('&');
    }

    const url: string = `/networklog/logs?${queryString(request)}`;
    const result: ApiResponse<NetworkLogModel[]> = await this.httpService.getAsync(url);

    if (result.success) {
      return result.data;
    } else {
      console.log(result.message);
    }

    return null;
  }
}
