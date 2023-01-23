import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ExamAPIService } from 'src/app/services/exam-api.service';
import { Exam } from 'src/Models/Exam';

@Component({
  selector: 'app-show-results',
  templateUrl: './show-results.component.html',
  styleUrls: ['./show-results.component.css']
})
export class ShowResultsComponent implements OnDestroy {
exam!:Exam;
userdegree!:number;
message!:string;
show!:string;
grade!:string;
x!:Subscription;
  constructor(private actRoute:ActivatedRoute,private examServices:ExamAPIService) 
  
  { 

    this.userdegree=parseInt(actRoute.snapshot.paramMap.get("degree") ||'0'); 
this.x=examServices.getbyID(parseInt(actRoute.snapshot.paramMap.get("examid") || '0')).subscribe(e=>{
  this.exam=e.result;

  if((this.userdegree/this.exam.finalDegree*100) < 50){
    this.message="Sorry You Have Failed the "+this.exam.name+" Test";
    this.show="Your score is "+this.userdegree+" / "+this.exam.finalDegree;
    this.grade="";
  }else if((this.userdegree/this.exam.finalDegree*100) >= 50 &&(this.userdegree/this.exam.finalDegree*100) < 60){
    this.message="Congeratulations You Have Passed the "+this.exam.name+" Test";
    this.show="Your score is "+this.userdegree+" / "+ this.exam.finalDegree ;
    this.grade="Your Grade is Acceptable";

  }else if((this.userdegree/this.exam.finalDegree*100) >= 60 &&(this.userdegree/this.exam.finalDegree*100) < 70){
    this.message="Congeratulations You Have Passed the "+this.exam.name+" Test";
    this.show="Your score is "+this.userdegree+" / "+ this.exam.finalDegree ;
    this.grade="Your Grade is Good";

  }else if((this.userdegree/this.exam.finalDegree*100) >= 70 &&(this.userdegree/this.exam.finalDegree*100) < 80){
    this.message="Congeratulations You Have Passed the "+this.exam.name+" Test";
    this.show="Your score is "+this.userdegree+" / "+ this.exam.finalDegree 
    this.grade=" Your Grade is Very Good"

  }else{
    this.message="Congeratulations You Have Passed the "+this.exam.name+" Test";
    this.show="Your score is "+this.userdegree+" / "+this.exam.finalDegree 
    this.grade=" Your Grade is Excellent"
  }

})



    
  }
  ngOnDestroy(): void {
    if(this.x){
      this.x.unsubscribe();
    }
  }


}
