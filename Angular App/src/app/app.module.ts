import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './components/index/index.component';
import{HttpClientModule} from'@angular/common/http';
import { ExamAPIService } from './services/exam-api.service';

import { NotfoundComponent } from './components/notfound/notfound.component';

import { AuthquardGuard } from './shared/authquard.guard';
import { FormsModule } from '@angular/forms';
import { ContactComponent } from './components/contact/contact.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { CommonModule } from '@angular/common';
import { ExamModule } from 'src/exam/exam.module';




@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,

    NotfoundComponent,
   
     ContactComponent,
         UserProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserModule,
    CommonModule,
    
 

  ],
  providers: [AuthquardGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
