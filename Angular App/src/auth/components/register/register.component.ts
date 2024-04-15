import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { IdentityAPIService } from 'src/app/services/identity-api.service';
import { signup } from 'src/Models/signup';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnDestroy {
  errormessage!:string[];
  checked:boolean=false;
  x:Subscription=new Subscription

  constructor(private identityServices:IdentityAPIService,private router:Router) { }

register(Form:NgForm){
this.errormessage=[];
  var signup:signup = {
    "username":Form.value['username'],
    "password":Form.value['password'],
    "mail":Form.value['email'],
    "confirmpassword":Form.value['conpassword']
  };
  
 this.x= this.identityServices.Register(signup).subscribe(e=>{
    if(e.statusCode==200){
this.router.navigate(['/auth/login'])
    }else{

        this.errormessage=e.message;
        console.log(this.errormessage);
      
   
      
    }
  })
}
check(event:any){
  this.checked=event.target.checked
    
  }

  ngOnDestroy(): void {

      this.x.unsubscribe();
    
  }
}
