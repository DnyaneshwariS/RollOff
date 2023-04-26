import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';
import { ViewEmployeeComponent } from './employees/view-employee/view-employee.component';
import { RolloffComponent } from './rolloff/rolloff.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './shared/guard/auth.guard';
import { HomeComponent } from './Home/home/home.component';
import { AccountEmpListComponent } from './account-emp-list/account-emp-list.component';
import { SuperAdminEmpListComponent } from './super-admin-emp-list/super-admin-emp-list.component';
import { SuperGuard } from './shared/guard/super.guard';
import { PSPAuthGuard } from './shared/guard/psp-auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'app-login', component: LoginComponent },
  { path: 'app-register', component: RegisterComponent},
  { path: 'app-employees', component: EmployeesComponent },
  { path: 'app-employees/:id', component: ViewEmployeeComponent},
  { path: 'app-rolloff/:id', component: RolloffComponent},
  { path: 'app-account', component: AccountEmpListComponent},
  { path: 'app-super', component: SuperAdminEmpListComponent},
  { path: '**', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
