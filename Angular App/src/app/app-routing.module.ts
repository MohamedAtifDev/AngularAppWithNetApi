import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ContactComponent } from './components/contact/contact.component';
import { IndexComponent } from './components/index/index.component';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { ShowExamComponent } from '../exam/show-exam/show-exam.component';
import { AuthquardGuard } from './shared/authquard.guard';
import { UserProfileComponent } from './components/user-profile/user-profile.component';

const routes: Routes = [{path:'home',component:IndexComponent}
,{path:'',redirectTo:'/home',pathMatch:'full'},
{path:"userprofile",component:UserProfileComponent},
{path:'contact',component:ContactComponent,canActivate:[AuthquardGuard]},
{path:'auth',loadChildren:()=>import("../auth/auth.module").then(m=>m.AuthModule)},
{path:'exam',loadChildren:()=>import("../exam/exam.module").then(m=>m.ExamModule)}
,{path:"**",component:NotfoundComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
