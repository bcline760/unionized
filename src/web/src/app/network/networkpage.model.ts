import { NetworkLogModel } from '../model/network-log.model';

export class NetworkPage {
    constructor() {
        this.logs = null;
    }

    public logs: NetworkLogModel[] | null;
}
