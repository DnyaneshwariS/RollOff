import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserService } from 'src/app/shared/service/user/user.service';

@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.css']
})
export class TopNavComponent {
  public constructor(private jwtHelper: JwtHelperService, private router: Router, private readonly userService: UserService) { }

  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    return false;
  }

  /**
   * roleBased
   */
  public accountBased() {
    const userDetails = this.userService.userDetails$.value;
    if (userDetails && userDetails.role === "Accounts") {
      return true;
    }
    return false;
  }

  public superBased() {
    const userDetails = this.userService.userDetails$.value;
    if (userDetails && userDetails.role === "SuperAdmin") {
      return true;
    }
    return false;
  }

  public adminBased() {
    const userDetails = this.userService.userDetails$.value;
    if (userDetails && userDetails.role === "Admin") {
      return true;
    }
    return false;
  }

  public logOut = () => {
    localStorage.removeItem("jwt");
    this.router.navigate(["app-login"]);
  }
}
