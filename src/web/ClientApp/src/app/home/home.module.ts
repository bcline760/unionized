import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DataTablesModule } from 'angular-datatables';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { ShowAlertDirective } from './show-alert.directive';


@NgModule({
  declarations: [HomeComponent, ShowAlertDirective],
  imports: [
    CommonModule,
    DataTablesModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
