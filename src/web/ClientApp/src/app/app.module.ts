import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { LoginModule } from './login/login.module';
import { HomeModule } from './home/home.module';
import { AppRoutingModule } from './app-routing.module';
import { NetlogModule } from './netlog/netlog.module';

import { SessionService } from '../service/session.service';
import { HttpService } from '../service/http.service';
import { StorageServiceModule } from 'ngx-webstorage-service';
import { AuthGuardService } from '../service/auth-guard.service';

import { AppComponent } from './app.component';
import { JwtModule, JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../environments/environment';

export function tokenGetter() {
    return localStorage.getItem(environment.tokenStorageKey);
}
@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        BrowserModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: tokenGetter,
                throwNoTokenError: false,
                whitelistedDomains: ['https://localhost:44390/']
            }
        }),
        StorageServiceModule,
        AppRoutingModule,
        LoginModule,
        HomeModule,
        NetlogModule
    ],
    providers: [HttpService, SessionService, AuthGuardService, JwtHelperService],
    bootstrap: [AppComponent]
})
export class AppModule { }
