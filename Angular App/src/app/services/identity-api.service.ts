import { HttpClient, HttpClientModule, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customresponse } from 'src/Models/Customrespone';
import { signin } from 'src/Models/Signin';
import { signup } from 'src/Models/signup';
import { User } from 'src/Models/user';

@Injectable({
  providedIn: 'root'
})
export class IdentityAPIService {
state!: BehaviorSubject<boolean>;
   headers= new HttpHeaders()
  .set('content-type', 'application/json')
 
  constructor(private http:HttpClient) 
  { 
this.state=new BehaviorSubject<boolean>(false);
  }

 
  getuser(id:string):Observable<Customresponse<User>>{

    return this.http.get<Customresponse<User>>(`${environment.host}/Account/getuser/${id}`)
  }

  Login(Login:signin):Observable<Customresponse<User>>{
return this.http.post<Customresponse<User>>(`${environment.host}/Account/signin`,JSON.stringify(Login),{headers:this.headers})
  }

  Register(register:signup):Observable<Customresponse<User>>{
    return this.http.post<Customresponse<User>>(`${environment.host}/Account/SignUp`,JSON.stringify(register),{headers:this.headers})

  }
  isuserlogined(){
    return this.state;
  }
}
