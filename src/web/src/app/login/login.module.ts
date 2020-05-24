import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StorageServiceModule } from 'ngx-webstorage-service';
import { LoginComponent } from './login.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SignoutComponent } from './signout.component';

@NgModule({
    declarations: [LoginComponent, SignoutComponent],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        StorageServiceModule,
    ]
})
export class LoginModule { }
