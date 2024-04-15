import { Exam } from "./Exam";
import { User } from "./user";

export interface userExam{

  
     appUserID:string ;
   
 examID:number;
 
 degree:number 

 
      duration:string;
      exam?:Exam
      user?:User

}