import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subscription } from 'rxjs';
import { ExamAPIService } from 'src/app/services/exam-api.service';
import { IdentityAPIService } from 'src/app/services/identity-api.service';
import { UserexamApiService } from 'src/app/services/userexam-api.service';
import { Customresponse } from 'src/Models/Customrespone';
import { Exam } from 'src/Models/Exam';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements  OnDestroy {
exams!:Exam[];
status:any;
ids:number[]=[];
x:Subscription;
y:Subscription;
errormessage!:string;
  constructor(private examservices:ExamAPIService,private userexamservice:UserexamApiService,private identityservice:IdentityAPIService,private router:Router,private activatedRoute:ActivatedRoute) 
  
  { 
    this.x=this.examservices.getAll().subscribe(e=>{
      if(e.statusCode==200){
        this.exams=e.result
      }else{
this.errormessage=e.message
      }
      
      });

this.y=this.identityservice.state.asObservable().subscribe(c=>{
  console.log(c);
  
  if(c){


    this.userexamservice.getById(sessionStorage.getItem("userKey")||'0').subscribe(e=>{

     
        for (let index = 0; index <e.result.length; index++) {
     
          this.ids.push(e.result[index].examID)
        }
      
    
    })
  }else{
    this.ids=[]
  }
})

console.log(this.ids);


  }
  
  ngOnDestroy(): void {

   this.y.unsubscribe();
 
   this.x.unsubscribe();
 
  }
isexist(id:number):boolean{


return this.ids.indexOf(id)!=-1;
}

 TrackBy(index:number, exam:Exam) {
  return exam.id;
}
}
