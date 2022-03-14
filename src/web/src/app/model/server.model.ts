import { DataModel } from './data-model.model';
import { sub } from 'angular-ui-bootstrap';

/**
 * Provides a model for server data
 */
export class ServerModel extends DataModel {
  constructor() {
    super();

    this.hostName = null;
    this.ipAddress = null;
    this.online = false;
  }

  /**
   * The configured hostname of the server
   */
  public hostName: string | null;

  /**
   * The IP address of the server
   */
  public ipAddress: string | null;

  /**
   * Indicates whether the current server is online or not
   */
  public online: boolean;
}
