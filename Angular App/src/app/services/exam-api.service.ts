import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customresponse } from 'src/Models/Customrespone';
import { Exam } from 'src/Models/Exam';

@Injectable({
  providedIn: 'root'
})
export class ExamAPIService {

  constructor(private HttpClient:HttpClient) {


   }
   getAll():Observable<Customresponse<Exam[]>>{
     return this.HttpClient.get<Customresponse<Exam[]>>(`${environment.host}/api/Exam`)
   }

   getbyID(id:number):Observable<Customresponse<Exam>>{
    return this.HttpClient.get<Customresponse<Exam>>(`${environment.host}/api/Exam/${id}`);
  }
}
