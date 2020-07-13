import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';\
import { AppRoutingModule } from './app-routing.module';
// import { NetlogModule } from './netlog/netlog.module';
import { StorageServiceModule } from 'ngx-webstorage-service';

import { AppComponent } from './app.component';
import { JwtModule, JwtHelperService } from '@auth0/angular-jwt';
import { LoginComponent } from './login/login.component';
import { OverlayModule } from '@angular/cdk/overlay';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

export function tokenGetter() {
    return localStorage.getItem(environment.tokenStorageKey);
}
@NgModule({
    declarations: [
        AppComponent,
        SiteLayoutComponent,
        LoadingOverlayComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        BrowserModule,
        JwtModule.forRoot({
            config: {
                tokenGetter: tokenGetter,
                throwNoTokenError: false,
                whitelistedDomains: [`https://${environment.domain}/`]
            }
        }),
        StorageServiceModule,
        OverlayModule,
        AppRoutingModule,
        LoginModule,
        HomeModule,
        FontAwesomeModule,
        PageNotFoundModule
        //NetlogModule
    ],
    entryComponents: [LoadingOverlayComponent],
    providers: [HttpService, SessionService,
        AuthGuardService, JwtHelperService],
    bootstrap: [AppComponent]
})
export class AppModule { }
