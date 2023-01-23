import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ExamAPIService } from 'src/app/services/exam-api.service';
import { UserexamApiService } from 'src/app/services/userexam-api.service';
import { Exam } from 'src/Models/Exam';
import { userExam } from 'src/Models/userExam';

@Component({
  selector: 'app-showtopers',
  templateUrl: './showtopers.component.html',
  styleUrls: ['./showtopers.component.css']
})
export class ShowtopersComponent implements OnDestroy  {
examid!:number;
exam!:Exam;
results:userExam[]=[];
x!:Subscription;
y!:Subscription;
  constructor(private actRoute:ActivatedRoute,private userexamServices:UserexamApiService,private examServices:ExamAPIService) {

    this.examid=Number(actRoute.snapshot.paramMap.get("examid"));
    this.x=examServices.getbyID(this.examid).subscribe(e=>{
      this.exam=e.result;
    })
   this.y= this.userexamServices.gettoppers(this.examid).subscribe(e=>{
this.results=e.result;
console.log(this.results);

    })
   }
  ngOnDestroy(): void {
    if(this.x){
      this.x.unsubscribe();
    }if(this.y){
      this.y.unsubscribe();
    }
  }
Tracking(index:number,data:userExam){
  return data.appUserID;
}

}
