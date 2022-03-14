import { Injectable } from '@angular/core';
import { HttpClientService } from './http-client.service';
import { AppService } from './app.service';
import { ApiResponse } from '../model/api-response.model';
import { ServerModel } from '../model/server.model';

@Injectable({
  providedIn: 'root'
})
export class ServerService extends AppService {

  constructor(protected httpService: HttpClientService) {
    super(httpService);
  }

  /**
   * Checks all servers to see if they are online or not.
   *
   * @returns List of servers and their availability status or null if an error occured
   */
  async checkServersAsync(): Promise<ApiResponse<ServerModel[]> | null> {
    const url: string = '/server/check';

    try {
      const response: ApiResponse<ServerModel[]> = await this.httpService.getAsync(url);

      return response;
    } catch (e) {
      this.handleError(e);
    }

    return null;
  }

  /**
   * Get all the servers from the API
   *
   * @returns All the servers or null if an error occured.
   */
  async getAllAsync(): Promise<ApiResponse<ServerModel[]> | null> {
    const url: string = '/server';

    const response: ApiResponse<ServerModel[]> = await this.httpService.getAsync(url);

    return response;
  }

  /**
   * Get a single monitored server record.
   * @param slug The slug of the server record
   * @returns The `ServerModel` matching the `slug` parameter or null if an error occured
   */
  async getServerAsync(slug: string): Promise<ApiResponse<ServerModel> | null> {
    const url: string = `/server/${slug}`;

    try {
      const response: ApiResponse<ServerModel> = await this.httpService.getAsync(url);

      return response;
    } catch (e) {
      this.handleError(e);
    }
    return null;
  }

  /**
   * Create a new server to be stored.
   * @param model The new server to create in the back end
   */
  async createServer(model: ServerModel): Promise<ApiResponse<number> | null> {
    const url: string = '/server';

    try {
      const response: ApiResponse<number> = await this.httpService.postAsync(url, model);

      return response;
    } catch (e) {
      this.handleError(e);
    }
    return null;
  }

  /**
   * Deletes a server record
   * @param slug The slug of the server to mark as deleted
   */
  async deleteServer(slug: string): Promise<ApiResponse<number> | null> {
    const url: string = `/server/${slug}`;

    try {
      const response: ApiResponse<number> = await this.httpService.deleteAsync(url);
    } catch (e) {
      this.handleError(e);
    }

    return null;
  }
}
