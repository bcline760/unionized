import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { LoginModule } from './login/login.module';
import { HomeModule } from './home/home.module';
import { AppRoutingModule } from './app-routing.module';
import { NetlogModule } from './netlog/netlog.module';
import { HttpService } from '../service/http.service';
import { SessionService } from '../service/session.service';
import { StorageServiceModule } from 'ngx-webstorage-service';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        BrowserModule,
        StorageServiceModule,
        AppRoutingModule,
        LoginModule,
        HomeModule,
        NetlogModule
    ],
    providers: [HttpService, SessionService],
    bootstrap: [AppComponent]
})
export class AppModule { }
