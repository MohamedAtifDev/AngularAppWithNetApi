import { Answer } from "./Answer";
import { Question } from "./Question";

export interface Exam{
  id:number ,
  name:string,
    description:string,
    finalDegree:number;
    imgurl:string,
    duration:number
  questions:Question[]
  havePassed:boolean
 


}