import { Answer } from "./Answer";

export interface Question{
  


        id:number ,
        text:string,
        correctAnswer:string,
         
          examID:number,
          
          answers:Answer[]
}