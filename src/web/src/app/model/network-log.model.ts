export class NetworkLogModel {
  constructor() {
    this.logDate = null;
    this.rule = null;
    this.interfaceIn = null;
    this.interfaceOut = null;
    this.macAddress = null;
    this.sourceAddress = null;
    this.sourcePort = null;
    this.destinationAddress = null;
    this.destinationPort = null;
    this.packetLength = 0;
    this.protocol = null;
    this.timeToLive = 0;
    this.tcpAction = null;
    this.icmpSequence = null;
  }

  public logDate: Date | null;
  public rule: string | null;
  public interfaceIn: string | null;
  public interfaceOut: string | null;
  public macAddress: string | null;
  public sourceAddress: string | null;
  public destinationAddress: string | null;
  public packetLength: number;
  public timeToLive: number;
  public protocol: string | null;
  public sourcePort: number | null;
  public destinationPort: number | null;
  public tcpAction: string | null;
  public icmpSequence: number | null;
}
