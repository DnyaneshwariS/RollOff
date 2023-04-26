import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { EmployeeDetailsService } from '../employees/employee-details.service';
import { UserService } from '../shared/service/user/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, OnDestroy {

  repeatPass: string = 'none';
  displayingMsg: string = '';
  isAccountCreated: boolean = false;
  private subscription = new Subscription();
  constructor(private userService: UserService, private router: Router) { }

  public ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  ngOnInit(): void {
    
  }

  selectedTeam = '';
  onSelected(value: string): void {
    this.selectedTeam = value;
  }
  registerForm = new FormGroup({
    name: new FormControl("", [Validators.required, Validators.minLength(2), Validators.pattern("[a-zA-z].*")]),

    email: new FormControl("", [Validators.required, Validators.email]),

    Password: new FormControl("", [Validators.required, Validators.minLength(6),
    Validators.maxLength(12)]),
    role: new FormControl(""),
    cpwd: new FormControl(""),
  });

  registerSubmitted() {
    if (this.Password.value == this.CPWD.value) {
      this.subscription.add(this.userService.addUser(this.registerForm.value).subscribe(res => {
        if (!res) {
          alert("User Already Exist.")
          this.isAccountCreated = false;
        }
        
        alert('Account Created Successfully');
        this.router.navigate(["/app-login"]);
        this.isAccountCreated = true;
      }));
    } else {
      this.repeatPass = 'inline'
    }
  }

  get Name(): FormControl {
    return this.registerForm.get("name") as FormControl;
  }

  get Email(): FormControl {
    return this.registerForm.get("email") as FormControl;
  }
  get Password(): FormControl {
    return this.registerForm.get("Password") as FormControl;
  }
  get Role(): FormControl {
    return this.registerForm.get("role") as FormControl;
  }
  get CPWD(): FormControl {
    return this.registerForm.get("cpwd") as FormControl;
  }

}

