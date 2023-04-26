import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { EmployeeDetailsService } from '../employees/employee-details.service';
import { Employee } from '../Models/ui-models/Employee.models';
import { RollOffTransaction } from '../shared/models/roll-off.model';
import { RollOffService } from '../shared/service/rollOff/roll-off.service';
import { UserService } from '../shared/service/user/user.service';

@Component({
  selector: 'app-rolloff',
  templateUrl: './rolloff.component.html',
  styleUrls: ['./rolloff.component.css']
})
export class RolloffComponent implements OnInit {
  private subscription = new Subscription();
  public constructor(private router: ActivatedRoute, private rollOffService: RollOffService,
  private userService: UserService, private employeeDetailsService: EmployeeDetailsService) {}
  public rollOff: any;
  public employee: Employee={
    globalGroupID:0 ,
    employeeNo: 0,
    name: '',
    localGrade: '',
    mainClient: '',
    email: '',
    joiningDate:new Date,
    projectCode:0 ,
    projectName: '',
    projectStartDate:new Date,
    projectEndDate: new Date,
    peopleManager: '',
    practice: '',
    pspName: '',
    newGlobalPractice: '',
    officeCity: '',
    country: ''
  }

  public ngOnInit(): void {
    const employeeId = this.router.snapshot.paramMap.get('id');
    this.subscription.add(this.employeeDetailsService.getEmployeebyid(employeeId).subscribe((response)=>{
        this.employee=response;
      }
    ));

    // this.subscription.add(this.rollOffService.GetRollOffFormByEmpId(employeeId).subscribe((response)=>{
    //   this.rollOff = response;
    //   this.rollOffForm.patchValue({
    //     primarySkill: response.rollOffForm.primarySkill,
    //     endDate: response.rollOffForm.endDate,
    //     reason: response.rollOffForm.reason,
    //     otherReason: response.rollOffForm.otherReason,
    //     performanceIssue: response.rollOffForm.performanceIssue.toString(),
    //     resgined: response.rollOffForm.resgined.toString(),
    //     underProbation: response.rollOffForm.resgined.toString(),
    //     longLeave: response.rollOffForm.resgined.toString(),
    //     leaveType: response.rollOffForm.resgined.toString(),
    //     technicalSkill: response.feedbackForm.technicalSkill,
    //     communication: response.feedbackForm.communication,
    //     roleCompetencies: response.feedbackForm.roleCompetance,
    //     remarks: response.feedbackForm.remarks,
    //     relevantExperience: response.feedbackForm.relevantExperience.toString()
    //   });
    // }));
  }

  public rollOffForm = new FormGroup({
    primarySkill: new FormControl('', [Validators.required]),
    endDate: new FormControl('', [Validators.required]),
    reason: new FormControl('', [Validators.required]),
    otherReason: new FormControl(''),
    performanceIssue: new FormControl('', [Validators.required]),
    resgined: new FormControl('', [Validators.required]),
    underProbation: new FormControl('', [Validators.required]),
    longLeave: new FormControl('', [Validators.required]),
    leaveType: new FormControl('', [Validators.required]),
    technicalSkill: new FormControl('', [Validators.required]),
    communication: new FormControl(''),
    roleCompetencies: new FormControl(''),
    remarks: new FormControl('', [Validators.required]),
    relevantExperience: new FormControl('', [Validators.required]),
    employeeId: new FormControl(this.router.snapshot.paramMap.get('id')),
    userDetailsId: new FormControl(''),
    roleType: new FormControl(1)
  });
  
  /**
   * Login
  */
  public onSubmit() {
    if (!this.rollOffForm.valid) {
      return;
    }

    this.rollOffForm.value.userDetailsId = this.userService.userDetails$.value.id;
    this.subscription.add(this.rollOffService.saveRollOffForm(this.rollOffForm.value).subscribe((response)=>{
      console.log(response);
    }));
  }
}
