import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IdentityAPIService } from 'src/app/services/identity-api.service';
import { UserexamApiService } from 'src/app/services/userexam-api.service';
import { User } from 'src/Models/user';
import { userExam } from 'src/Models/userExam';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnDestroy  {
user!:User;
chars=['0','1','2','3','4','5','6','7','8','9','A','B','C','D','E','F'];
color="";
userexams:userExam[]=[]
x!:Subscription;
y!:Subscription;
  constructor(private identityService:IdentityAPIService,private userexamService:UserexamApiService) {
    var id=sessionStorage.getItem("userKey");
    if(id!=null){
      this.x=this.identityService.getuser(id).subscribe(e=>{
        console.log(e);
        
      this.user=e.result;
        
      })
    }

    for (let i = 0; i < 6; i++) {
      var char=this.chars[Math.floor(Math.random()*16)];
this.color+=char;
       
     }
     if(this.color=="000000"){
      this.color="#"+"AAAAAA"
     }else{
       this.color="#"+this.color
     }
 
     console.log(this.color);
     
    this.y= userexamService.getById(sessionStorage.getItem("userKey")||'0').subscribe(e=>{
     console.log(e.result);
     
     this.userexams=e.result
   })

     
   }
  ngOnDestroy(): void {
    if(this.y){
      this.y.unsubscribe();
    }if(this.x){
      this.x.unsubscribe();
    }
  }




}
