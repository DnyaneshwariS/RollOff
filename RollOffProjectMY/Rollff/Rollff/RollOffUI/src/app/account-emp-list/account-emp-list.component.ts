import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { Employee, PSPTransaction } from '../Models/ui-models/Employee.models';
import { RollOffTransaction } from '../shared/models/roll-off.model';
import { RollOffService } from '../shared/service/rollOff/roll-off.service';
import { UserService } from '../shared/service/user/user.service';

@Component({
  selector: 'app-account-emp-list',
  templateUrl: './account-emp-list.component.html',
  styleUrls: ['./account-emp-list.component.css']
})
export class AccountEmpListComponent implements OnInit {
  public displayedColumns: string[] = ['globalGroupID','employeeNo','name','localGrade','email','isActivated'];
  public dataSource = new MatTableDataSource<PSPTransaction>();
  public filterString='';
  private subscription = new Subscription();
  @ViewChild(MatPaginator) matPaginator!:MatPaginator;

  constructor(private rollOffService: RollOffService, private userService: UserService){}

  public ngOnInit(): void {
    //fetch employees
    this.subscription.add(this.rollOffService.GetRollOffFormList().subscribe((successResponse)=>{
      this.dataSource=new MatTableDataSource<PSPTransaction>(successResponse);
      if(this.matPaginator){
        this.dataSource.paginator=this.matPaginator;
      }
    }))
  }
  public filterEmployees(){
    this.dataSource.filter= this.filterString.trim().toLowerCase();
  }

  /**
   * onTransfered
  */
  public onTransfered(element: any) {
    const id = this.userService.userDetails$.value.id;
    this.subscription.add(this.rollOffService.SaveTransfered(element.employee.globalGroupID, id).subscribe((response)=>{
      if (response) {
       
      }
    }))
  }
}
