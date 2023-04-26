import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserService } from '../service/user/user.service';

@Injectable({
  providedIn: 'root'
})
export class SuperGuard implements CanActivate  {

  constructor(private router:Router, private jwtHelper: JwtHelperService, private readonly userService: UserService){}
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const token = localStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)){
      const userDetails =this.userService.userDetails$.value;
      if (userDetails && userDetails.role === "SuperAdmin") {
          return true;
      }
      this.router.navigate(["/"]);
      return false;
    }

    this.router.navigate(["app-login"]);
    return false;
  }
}