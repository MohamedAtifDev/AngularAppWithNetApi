import { formatCurrency } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IdentityAPIService } from 'src/app/services/identity-api.service';
import { signin } from 'src/Models/Signin';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnDestroy  {
checked:boolean=false;
errormessage:string="";
x!:Subscription
  constructor(private identityService:IdentityAPIService,private router:Router, private route: ActivatedRoute) { }
 

  Login(Form:NgForm){
this.errormessage="";

var sign:signin = {
  "username":Form.value['username'],
  "password":Form.value['password'],
  "remember":this.checked
};



this.x=this.identityService.Login(sign).subscribe(e=>{
  console.log(e);
  
  if(e.statusCode==400){
    this.errormessage=e.message;
    this.identityService.state.next(false);
  }else{
   // const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    //console.log(returnUrl);
    this.identityService.state.next(true);
   
    
    sessionStorage.setItem("userKey",e.result.id );
    this.router.navigate(['/home'])

    
  }
});


}
check(event:any){
this.checked=event.target.checked
  
}
ngOnDestroy(): void {
if(this.x){
  this.x.unsubscribe();
}
}

}


