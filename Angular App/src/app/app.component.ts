import { Component, HostListener, OnInit, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { IdentityAPIService } from './services/identity-api.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
 status:any;

 date=new Date();
  year:any;
login:boolean=false;


  constructor(private identitService:IdentityAPIService,private router:Router,private renderer2: Renderer2) {

 

this.year=this.date.getFullYear();

this.identitService.state.subscribe(e=>this.login=e);
if(sessionStorage.getItem("userKey")!=null){
  this.login=true;
}else{
  this.login=false;
}
  }

  logout(){
    sessionStorage.removeItem("userKey");
    this.identitService.state.next(false);
    this.router.navigate(['/home'])

  }

  }




