import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customresponse } from 'src/Models/Customrespone';
import { sendmail } from 'src/Models/sendmail';

@Injectable({
  providedIn: 'root'
})
export class SendmailService {
  headers= new HttpHeaders()
  .set('content-type', 'application/json')
  constructor(private http:HttpClient) { 

  }

  sendmail(data:sendmail):Observable<Customresponse<boolean>>{
    return this.http.post<Customresponse<boolean>>(`${environment.host}7164/api/MailSender`, JSON.stringify(data),{headers:this.headers})
  }
}
