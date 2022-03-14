import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SessionRoutingModule } from './session-routing.module';
import { LoginComponent } from './login/login.component';
import { SessionComponent } from './session.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [LoginComponent, SessionComponent],
  imports: [
    CommonModule,
    FormsModule,
    SessionRoutingModule
  ]
})
export class SessionModule { }
