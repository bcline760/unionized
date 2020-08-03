import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataTablesModule } from 'angular-datatables';
import { NetworkRoutingModule } from './network-routing.module';
import { NetworkComponent } from './network.component';


@NgModule({
  declarations: [NetworkComponent],
  imports: [
    CommonModule,
    DataTablesModule,
    NetworkRoutingModule
  ]
})
export class NetworkModule { }
