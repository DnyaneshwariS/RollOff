import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserService } from '../shared/service/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  private subscription = new Subscription();
  public constructor(private router: Router, private userService: UserService) {}
  public loginForm = new FormGroup({
    userName: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });
  
  /**
   * Login
  */
  public onSubmit() {
    if (!this.loginForm.valid) {
      return;
    }
    this.subscription.add(this.userService.authenticate(this.loginForm.value).subscribe((response)=>{
      localStorage.setItem('jwt', response.token)
      this.userService.userDetails$.next(response);
      this.router.navigate(["/"]);
    }));
  }
}
