import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ShowExamComponent } from './show-exam/show-exam.component';
import { ShowtopersComponent } from './showtopers/showtopers.component';
import { AuthquardGuard } from 'src/app/shared/authquard.guard';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ShowResultsComponent } from './show-results/show-results.component';
const routes: Routes = [{path:'ShowToppers/:examid',component:ShowtopersComponent,canActivate:[AuthquardGuard]},{path:'showExam/:id',component:ShowExamComponent,canActivate:[AuthquardGuard]},{path:'showresult/:degree/:examid',component:ShowResultsComponent},{path:'showtopers',component:ShowtopersComponent,canActivate:[AuthquardGuard]}]



@NgModule({
 
  declarations: [
    ShowExamComponent,
    ShowResultsComponent,
    ShowtopersComponent
  ],
  imports: [
    CommonModule,  [RouterModule.forChild(routes)],
    FormsModule

  
  ],

})
export class ExamModule { }
