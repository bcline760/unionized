import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CertificatesComponent } from './certificates.component';
import { AuthGuardService } from '../service/auth-guard.service';


const routes: Routes = [
  {
    path: 'certificates',
    component: CertificatesComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CertificatesRoutingModule { }
