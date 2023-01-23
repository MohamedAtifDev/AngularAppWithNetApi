import { ThisReceiver } from '@angular/compiler';
import { AfterViewInit, Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { CheckboxControlValueAccessor, NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, timer } from 'rxjs';
import { ExamAPIService } from 'src/app/services/exam-api.service';
import { UserexamApiService } from 'src/app/services/userexam-api.service';
import { Answer } from 'src/Models/Answer';
import { Exam } from 'src/Models/Exam';
import { Question } from 'src/Models/Question';
import { userExam } from 'src/Models/userExam';

@Component({
  selector: 'app-show-exam',
  templateUrl: './show-exam.component.html',
  styleUrls: ['./show-exam.component.css']
})
export class ShowExamComponent implements AfterViewInit, OnDestroy {
exam!:Exam;
time:number=0;
timeout!:number;;
minutes!:string;
seconds!:string;
degree:number=0;
finalDuration!:number;
questiondegree!:number;
x!:Subscription;y!:Subscription;z!:Subscription;
@ViewChild('f') form!:ElementRef<HTMLFormElement>;

  constructor(private router:Router,private activatedrouter:ActivatedRoute,private examservice:ExamAPIService,private userexamServices:UserexamApiService) {
this.x=activatedrouter.paramMap.subscribe(e=>{
var id=parseInt(e.get("id")?.toString() ||"0")
this.z=this.examservice.getbyID(id).subscribe(e=>{
this.exam=e.result;
this.time=e.result.duration;
this.timeout=this.time*60*1000;
this.questiondegree=e.result.finalDegree/e.result.questions.length;

  
})

})
var interval=setInterval(() =>{
  var timeleft=this.timeout-1000;

if(timeleft==0){
clearInterval(interval)
for (let index = 0; index < this.exam.questions.length; index++) {
  if((this.form as unknown as NgForm).form.value[index]==this.exam.questions[index].correctAnswer){
  this.degree++;
  }
}
var userex:userExam={
  "appUserID":sessionStorage.getItem("userKey") ||"0",
  "examID":this.exam.id,
  "degree":this.degree*this.questiondegree,
  "duration":this.exam.duration.toString()
}
this.y=this.userexamServices.Add(userex).subscribe(e=>{
  if(e.statusCode==200){
   this.router.navigate(['/exam/showresult',this.degree*this.questiondegree,this.exam.id])

  }else{
   this.router.navigate(['/home'])

  }
}) 



}else{

  this.minutes = Math.floor((timeleft % (1000 * 60 * 60)) / (1000 * 60)).toString();
  this.seconds = Math.floor((timeleft % (1000 * 60)) / 1000).toString();
  if(this.seconds.toString().length==1){
this.seconds="0"+this.seconds
  }
  this.timeout=this.timeout-1000;
}

 },1000)
}
  ngAfterViewInit(): void {
    console.log((this.form as unknown as NgForm).form.value);
  }


check(form:NgForm){
for (let index = 0; index < this.exam.questions.length; index++) {
if(form.value[index]==this.exam.questions[index].correctAnswer){
this.degree++;
}
 
  
}

var mins=parseInt(this.minutes)*60;
var secs=parseInt(this.seconds)
this.finalDuration=(this.exam.duration*60)-(mins+secs);
mins=Math.floor((this.finalDuration % (1000 * 60 * 60)) / (1000 * 60));
secs=this.finalDuration-(mins*60);
var finalsecs=""


if(secs.toString().length==1){
finalsecs="0"+secs.toString();
}else{
  finalsecs=secs.toString();
}
var userex:userExam={
  "appUserID":sessionStorage.getItem("userKey") ||"0",
  "examID":this.exam.id,
  "degree":this.degree*this.questiondegree,
  "duration":mins.toString()+":"+finalsecs
}
 this.y=this.userexamServices.Add(userex).subscribe(e=>{
   if(e.statusCode==200){
    this.router.navigate(['/exam/showresult',this.degree*this.questiondegree,this.exam.id])

   }else{
    this.router.navigate(['/home'])

   }
 }) 
}

TrackingQuestions(index:number,Question:Question){
  return Question.id;
}

TrackingAnswers(index:number,Answer:Answer){
  return Answer.id;
}
ngOnDestroy(): void {
  if(this.y){
    this.y.unsubscribe();
  }if(this.x){
    this.x.unsubscribe();
  }if(this.z){
    this.z.unsubscribe();
  }

}

}
