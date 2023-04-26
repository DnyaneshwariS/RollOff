import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { IUserAuthenticateResponse } from '../../models/user-response';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly apiUrl: string = environment.baseApiUrl;
  public readonly userDetails$ = new BehaviorSubject<any>(null);
  // private readonly headers = new HttpHeaders().set('Content-Type', 'application/json');
  constructor(private http: HttpClient) {}

  public addUser(data: any): Observable<any> {
    let API_URL = `${this.apiUrl}User/AddUser`;
    const userDetails = {
      name: data.name,
      email: data.email,
      password: data.Password,
      role: data.role
    }
    return this.http.post(API_URL, userDetails).pipe(catchError(this.error));
  }

  // Read
  public authenticate(data: any): Observable<IUserAuthenticateResponse> {
    let API_URL = `${this.apiUrl}User/Authenticate?username=${data.userName}&password=${data.password}`
    return this.http.get<IUserAuthenticateResponse>(API_URL).pipe(catchError(this.error));
  }

  // Handle Errors
  public error(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(() => {
      return errorMessage;
    });
  }
}
 