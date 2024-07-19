import { Component } from '@angular/core';
import { AbstractControl, FormGroup, NonNullableFormBuilder, Validators } from '@angular/forms';
import { CompanyFormGroup } from '../../interfaces/company-form-group';
import { CompanyCodeValidator } from '../../validators/company-code.validator';
import { HttpClient } from '@angular/common/http';
import { Company } from '../../interfaces/company.interface';
import { tap } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html',
  styleUrl: './add-company.component.css'
})
export class AddCompanyComponent {

  public companyFormGroup!: FormGroup<CompanyFormGroup>;
  public isSaving = false;
  public isSaveError = false;

  constructor(
    private formBuilder: NonNullableFormBuilder, 
    private companyCodeValidator: CompanyCodeValidator,
    private http: HttpClient,
    private router: Router) {
     this.companyFormGroup = this.buildCompanyFormGroup();
  }

  public buildCompanyFormGroup(): FormGroup<CompanyFormGroup> {
    return new FormGroup<CompanyFormGroup>({
      name: this.formBuilder.control<string>('', 
        Validators.pattern('^[A-Za-z0-9 !-\\/:-@[-`{-~]*$')
      ),
      code: this.formBuilder.control<string>('', {
        validators: Validators.pattern('^[A-Z0-9]*$'),
        asyncValidators: [this.companyCodeValidator.validate.bind(this.companyCodeValidator)],
        updateOn: 'blur'
      }),
      sharePrice: this.formBuilder.control<number | undefined>(undefined, 
        Validators.pattern('^\\d*\\.?\\d{0,5}$')
      )
    });
  }

  public get controls() {
    return this.companyFormGroup.controls;
  }

  public save(): void {
    this.isSaving = true;
    const body: Company = {
      name: this.companyFormGroup.controls.name.value,
      code: this.companyFormGroup.controls.code.value,
      sharePrice: this.companyFormGroup.controls.sharePrice.value
    }
    this.http.post('https://localhost:7146/api/company', body)
      .pipe(
        tap((result) => {
          if (result) {
            this.isSaveError = false;
            this.isSaving = false;
            this.router.navigate(['/companies']);
          } else {
            this.isSaveError = true;
            this.isSaving = false;
          }
        },
        (error) => {
          this.isSaveError = true;
          this.isSaving = false;
          console.error(error);
        }
      ))
      .subscribe();
  }
}


