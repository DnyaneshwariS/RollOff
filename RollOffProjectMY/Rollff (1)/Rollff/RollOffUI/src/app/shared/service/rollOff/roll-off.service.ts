import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { RollOffTransaction } from '../../models/roll-off.model';

@Injectable({
  providedIn: 'root'
})
export class RollOffService {
  private readonly apiUrl: string = environment.baseApiUrl;
  // private readonly headers = new HttpHeaders().set('Content-Type', 'application/json');
  constructor(private http: HttpClient) { }

  public saveRollOffForm(data: any): Observable<any> {
    let API_URL = `${this.apiUrl}RollOff/SaveRollOffForm`;

    const rollOffTransaction = {
      rollOffFormDto: {
        primarySkill: data.primarySkill,
        endDate: data.endDate,
        reason: data.reason,
        otherReason: data.otherReason,
        performanceIssue: data.performanceIssue,
        resgined: data.resgined,
        underProbation: data.underProbation,
        longLeave: data.longLeave,
        leaveType: data.leaveType
      },
      feedbackFormDto: {
        technicalSkill: data.technicalSkill,
        communication: data.communication,
        roleCompetance: data.roleCompetance,
        remarks: data.remarks,
        relevantExperience: data.relevantExperience
      },
      assignedFromDto: {
        employeeId: data.employeeId,
        userDetailsId: data.userDetailsId,
        roleType: data.roleType
      }
    }

    return this.http.post(API_URL, rollOffTransaction).pipe(catchError(this.error));
  }

  // Read
  public GetRollOffFormByEmpId(employeeId: any): Observable<RollOffTransaction> {
    let API_URL = `${this.apiUrl}RollOff/GetRollOffFormByEmpId?employeeId=${employeeId}`
    return this.http.get<RollOffTransaction>(API_URL).pipe(catchError(this.error));
  }

   // Read
   public GetRollOffFormList(): Observable<any> {
    let API_URL = `${this.apiUrl}RollOff/GetRollOffFormList`
    return this.http.get<any>(API_URL).pipe(catchError(this.error));
  }

  // Read
  public GetTransferedList(): Observable<any> {
    let API_URL = `${this.apiUrl}RollOff/GetTransferedList`
    return this.http.get<any>(API_URL).pipe(catchError(this.error));
  }

  public UpdateTransfered(employeeId: number, userId: number): Observable<any> {
    let API_URL = `${this.apiUrl}RollOff/UpdateTransfered`
    const request = {
      employeeId: employeeId,
      assignedFrom: userId,
      isAactivate: true,
      isTransfered: false
    }
    return this.http.put(API_URL, request).pipe(catchError(this.error));
  }

  public SaveTransfered(employeeId: number, userId: number): Observable<any> {
    let API_URL = `${this.apiUrl}RollOff/SaveTransfered`
    const request = {
      employeeId: employeeId,
      assignedFrom: userId,
      isAactivate: false,
      isTransfered: true
    }
    return this.http.post(API_URL, request).pipe(catchError(this.error));
  }

// Handle Errors
  public error(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }

}
