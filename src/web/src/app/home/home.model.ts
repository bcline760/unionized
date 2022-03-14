import { ServerModel } from '../model/server.model';

/**
 * Provides a model for the "home" display component
 */
export class HomeModel {
  constructor() {
    this.serverList = null;
    this.tableOddClass = 'table-secondary';
  }

  /**
   * A list of servers to display
   */
  public serverList: ServerModel[] | null;

  public tableOddClass: string | null;
}
