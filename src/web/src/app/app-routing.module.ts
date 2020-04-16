import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';
import { HomeComponent } from './home/home.component';
import { AuthGuardService } from './service/auth-guard.service';

const appRoutes: Routes = [
    {
        path: '',
        component: SiteLayoutComponent,
        children: [
            { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuardService] }
            //{ path: 'net-log', component: Net}
        ]
    },
    {
        path: 'login',
        component: LoginComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes,
            { enableTracing: true } // <-- debugging purposes only
        )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }
