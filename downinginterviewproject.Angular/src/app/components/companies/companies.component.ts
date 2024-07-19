import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Company } from '../../interfaces/company.interface';
import { tap } from 'rxjs';

@Component({
  selector: 'app-companies',
  templateUrl: './companies.component.html',
  styleUrl: './companies.component.css'
})
export class CompaniesComponent implements OnInit {
  constructor(private http: HttpClient, private router: Router) { }

  public companies: Company[] = [];
  public loading = false;

  public ngOnInit(): void {
    this.getCompanies();
  }

  public getCompanies(): void {
    this.loading = true;
    this.http.get<Company[]>('https://localhost:7146/api/company')
      .pipe(
        tap((result) => {
            this.loading = false;
            this.companies = result;
          },
          (error) => {
            console.error(error);
          }
      ))
      .subscribe();
  }

  public navigateToAdd(): void {
    this.router.navigate(['/add'])
  }
}
