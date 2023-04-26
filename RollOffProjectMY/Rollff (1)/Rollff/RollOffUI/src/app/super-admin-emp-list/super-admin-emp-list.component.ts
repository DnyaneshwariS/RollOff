import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Subscription } from 'rxjs';
import { PSPTransaction } from '../Models/ui-models/Employee.models';
import { RollOffService } from '../shared/service/rollOff/roll-off.service';
import { UserService } from '../shared/service/user/user.service';

@Component({
  selector: 'app-super-admin-emp-list',
  templateUrl: './super-admin-emp-list.component.html',
  styleUrls: ['./super-admin-emp-list.component.css']
})
export class SuperAdminEmpListComponent {
  public displayedColumns: string[] = ['globalGroupID','employeeNo','name','localGrade','email','isActivated'];
  public dataSource = new MatTableDataSource<PSPTransaction>();
  public filterString='';
  private subscription = new Subscription();
  @ViewChild(MatPaginator) matPaginator!:MatPaginator;

  constructor(private rollOffService: RollOffService, private userService: UserService){}

  public ngOnInit(): void {
    //fetch employees
    const id = 1//this.userService.userDetails$.value.id;
    this.subscription.add(this.rollOffService.GetTransferedList().subscribe((successResponse)=>{
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
   public UpdateTransfered(element: any) {
    const id = this.userService.userDetails$.value.id;
    this.subscription.add(this.rollOffService.UpdateTransfered(element.employee.globalGroupID, id).subscribe((response)=>{
      if (response) {
       
      }
    }))
  }
}
