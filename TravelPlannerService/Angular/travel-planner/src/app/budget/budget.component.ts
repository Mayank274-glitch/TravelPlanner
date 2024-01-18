// budget.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ExpensesService } from '../services/expenses.service';

@Component({
  selector: 'app-budget',
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.css']
})
export class BudgetComponent implements OnInit {
  expenses: any[] = [];
  totalExpenses: number = 0;
  expenseForm!: FormGroup;

  constructor(private fb: FormBuilder, private expenseService: ExpensesService) 
  {}

  ngOnInit(): void {
    this.initExpenseForm();
    this.loadExpenses();
  }

  // Initialize the expense form
  initExpenseForm(): void {
    this.expenseForm = this.fb.group({
      category: ['', [Validators.required]],
      amount: [0, [Validators.required, Validators.min(0.01)]]
    });
  }

  // Load expenses from the API
  loadExpenses(): void {
    this.expenseService.getAllExpenses().subscribe(
      (response: any[]) => {
        this.expenses = response || [];
        this.calculateTotalExpenses();
      },
      (error) => {
        console.error('Error fetching expenses:', error);
        // Handle error scenarios
      }
    );
  }

  // Method to add a new expense
  addExpense(): void {
    if (this.expenseForm.valid) {
      const newExpense: any = this.expenseForm.value;
      this.expenseService.createExpense(newExpense).subscribe(
        (response: any) => {
          this.expenses.push(response);
          this.calculateTotalExpenses();
          this.initExpenseForm();
        },
        (error) => {
          console.error('Error adding expense:', error);
          // Handle error scenarios
        }
      );
    }
  }

  // Method to calculate the total expenses
  calculateTotalExpenses(): void {
    this.expenseService.getTotalExpenses().subscribe(
      (response: any) => {
        this.totalExpenses = response.total || 0;
      },
      (error) => {
        console.error('Error fetching total expenses:', error);
        // Handle error scenarios
      }
    );
  }
}
