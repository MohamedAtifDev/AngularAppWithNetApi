import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { SendmailService } from 'src/app/services/sendmail.service';
import { sendmail } from 'src/Models/sendmail';


@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnDestroy{
y!:Subscription;
  constructor(private sendmailsevices:SendmailService,private router:Router) { }

errormessage:string="";

sendEmail(form:NgForm){
  var send:sendmail={
    "message":form.value['message'],
    "mail":form.value['email']
  }

  
  this.y=this.sendmailsevices.sendmail(send).subscribe(e=>{
    if(e.result){
      this.router.navigate(['/home'])
    }else{
this.errormessage=e.message
    }
  })
}

ngOnDestroy(): void {
if(this.y){
  this.y.unsubscribe();
}
}
}
