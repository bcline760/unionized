import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AppRoutingModule } from './app-routing.module';
// import { NetlogModule } from './netlog/netlog.module';
import { StorageServiceModule } from 'ngx-webstorage-service';

import { AppComponent } from './app.component';
import { JwtModule, JwtHelperService } from '@auth0/angular-jwt';
import { OverlayModule } from '@angular/cdk/overlay';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        BrowserModule,
        //JwtModule.forRoot({
        //    config: {
        //        tokenGetter: tokenGetter,
        //        throwNoTokenError: false,
        //        whitelistedDomains: [`https://${environment.domain}/`]
        //    }
        //}),
        StorageServiceModule,
        OverlayModule,
        AppRoutingModule,
        FontAwesomeModule,
        //NetlogModule
    ],
    entryComponents: [],
    providers: [JwtHelperService],
    bootstrap: [AppComponent]
})
export class AppModule { }
