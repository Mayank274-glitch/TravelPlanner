// expenses.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';
import { ExpenseDto } from '../models/expense.model';
import { ExpenseTotalDto } from '../models/expense-total.model';

@Injectable({
  providedIn: 'root',
})
export class ExpensesService {
    private apiUrl: string; 

    constructor(private http: HttpClient, private configService: ConfigService) {
        this.apiUrl = this.configService.getApiUrl();
      }
    

  getAllExpenses(): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/expenses`);
  }

  createExpense(data: ExpenseDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/expenses`, data);
  }

  getExpenseDetails(id: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/expenses/${id}`);
  }

  updateExpense(id: string, data: ExpenseDto): Observable<any> {
    return this.http.put(`${this.apiUrl}/api/expenses/${id}`, data);
  }

  deleteExpense(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/api/expenses/${id}`);
  }

  getTotalExpenses(currency: string): Observable<ExpenseTotalDto> {
    return this.http.get<ExpenseTotalDto>(`${this.apiUrl}/api/expenses/total?currency=${currency}`);
  }
}
