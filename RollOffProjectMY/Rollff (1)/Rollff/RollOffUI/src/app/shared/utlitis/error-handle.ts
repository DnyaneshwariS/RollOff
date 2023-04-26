import { HttpErrorResponse } from "@angular/common/http";
import { throwError } from "rxjs";

 // Handle Errors
 export const error =(error: HttpErrorResponse) => {
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