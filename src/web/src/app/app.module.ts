//Angular modules
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';
import { JwtModule, JwtHelperService } from '@auth0/angular-jwt';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { OverlayModule } from '@angular/cdk/overlay';
import { StorageServiceModule } from 'ngx-webstorage-service';

//Routing module
import { AppRoutingModule } from './app-routing.module';

//Services
import { HttpClientService } from './service/http-client.service';
import { SessionService } from './service/session.service';

//Client modules
import { CertificatesModule } from './certificates/certificates.module';
import { HomeModule } from './home/home.module';
import { LayoutModule } from './layout/layout.module';
import { NetworkModule } from './network/network.module';
import { SessionModule } from './session/session.module';

//Client components
import { AppComponent } from './app.component';

export function fnTokenGetter() {
  return localStorage.getItem("access_token");
}

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        BrowserModule,
        HttpClientModule,
        JwtModule.forRoot({
           config: {
             tokenGetter: fnTokenGetter,
             allowedDomains: ["localhost", "unioinzed.unionsquared.lan"],
             throwNoTokenError: false
           }
        }),
        StorageServiceModule,
        LayoutModule,
        OverlayModule,
        FontAwesomeModule,
        CertificatesModule,
        HomeModule,
        NetworkModule,
        SessionModule,
        AppRoutingModule
    ],
    entryComponents: [],
    providers: [JwtHelperService, HttpClientService, SessionService],
    bootstrap: [AppComponent]
})
export class AppModule { }
