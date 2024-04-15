import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customresponse } from 'src/Models/Customrespone';
import { userExam } from 'src/Models/userExam';

@Injectable({
  providedIn: 'root'
})
export class UserexamApiService {
  headers= new HttpHeaders()
  .set('content-type', 'application/json')
  constructor(private http:HttpClient) {

   }
   getAll():Observable<Customresponse<userExam[]>>{
     return this.http.get<Customresponse<userExam[]>>(`${environment.host}/api/UserExam`);
   }
   getById(id:string):Observable<Customresponse<userExam[]>>{
    return this.http.get<Customresponse<userExam[]>>(`${environment.host}/api/UserExam/${id}`);
  }

  Add(userexam:userExam):Observable<Customresponse<userExam>>{
    return this.http.post<Customresponse<userExam>>(`${environment.host}/api/UserExam/`,JSON.stringify(userexam),{headers:this.headers});

  }

  gettoppers(examid:number):Observable<Customresponse<userExam[]>>{
    return this.http.get<Customresponse<userExam[]>>(`${environment.host}/getToppers/${examid}`,);

  }

}
