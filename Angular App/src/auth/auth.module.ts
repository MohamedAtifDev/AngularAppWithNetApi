import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { RegisterComponent } from './components/register/register.component';

const routes: Routes = [{path:'login',component:LoginComponent},{path:'register',component:RegisterComponent}]

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    CommonModule,
    [RouterModule.forChild(routes)],
    [RouterModule],
    FormsModule
      
  ],

})
export class AuthModule { }
