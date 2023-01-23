import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { IdentityAPIService } from '../services/identity-api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthquardGuard implements CanActivate {
  constructor(private router:Router) {
  
  
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {



     
      
if( sessionStorage.getItem("userKey")==null){



  this.router.navigate(['/auth/login']/*, { queryParams: { returnUrl: state.url }}*/);


return false;
}else{
  return true
}
  }
  
}
