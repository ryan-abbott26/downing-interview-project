import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AbstractControl, AsyncValidator, ValidationErrors } from "@angular/forms";
import { Observable, map, of } from "rxjs";

@Injectable({ providedIn: 'root' })
export class CompanyCodeValidator implements AsyncValidator {
  constructor(private http: HttpClient) { }

  public validate(control: AbstractControl): Observable<ValidationErrors | null> {
    const code = control.value as string;
    if (code.length === 0) return of(null);
    return this.http.get<boolean>('https://localhost:7146/api/company/code?code=' + code)
      .pipe(map((result: boolean) => result ? { codeAlreadyExists: true } : null))
  }
}