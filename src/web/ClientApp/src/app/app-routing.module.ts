import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeModule } from './home/home.module';
import { AuthGuardService } from './service/auth-guard.service';
import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';



const appRoutes: Routes = [
    {
        path: '',
        component: SiteLayoutComponent,
        children: [
            {
                path: '',
                pathMatch: 'full',
                canActivate: [AuthGuardService],
                //loadChildren: () => import('./home/home.module').then(m => HomeModule)
                component: HomeComponent
            },
            // {
            //     path: 'networking'
            // },
        ]
    },
    {
        path: 'login',
        loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
    },
    {
        path: '**',
        component: PageNotFoundComponent
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