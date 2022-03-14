import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeModule } from './home/home.module';
import { NetworkModule } from './network/network.module';
import { AuthGuardService } from './service/auth-guard.service';
import { CertificatesModule } from './certificates/certificates.module';
import { SessionModule } from './session/session.module';

const appRoutes: Routes = [
  {
    path: '',
    canActivate: [AuthGuardService],
    loadChildren: () => import('./home/home.module').then(m => HomeModule),
    data: { showFullLayout: true}
  },
  {
    path: 'certificates',
    canActivate: [AuthGuardService],
    loadChildren: () => import('./certificates/certificates.module').then(c => CertificatesModule),
    data: { showFullLayout: true}
  },
  {
    path: 'network',
    canActivate: [AuthGuardService],
    loadChildren: () => import('./network/network.module').then(n => NetworkModule),
    data: { showFullLayout: true}
  },
  {
    path: 'session',
    loadChildren: () => import('./session/session.module').then(s => SessionModule),
    data: { showFullLayout: false}
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
