// budget.component.ts
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ExpensesService } from '../services/expenses.service';
import { ExpenseDto } from '../models/expense.model';
import { ExpenseTotalDto } from '../models/expense-total.model';


@Component({
  selector: 'app-budget',
  templateUrl: './budget.component.html',
  styleUrls: ['./budget.component.css']
})
export class BudgetComponent implements OnInit {
  expenses: ExpenseDto[] = [];
  totalExpenses: number = 0;
  expenseForm!: FormGroup;
  selectedOption: string = 'Car rental';
  categories: string[] = ['Flights', 'Lodging', 'Car rental', 'Public transit', 'Food', 'Drinks', 'Sightseeing', 'Activities', 'Shopping', 'Gas', 'Groceries', 'Other'];

  constructor(private fb: FormBuilder, private expenseService: ExpensesService) 
  {}

  ngOnInit(): void {
    this.initExpenseForm();
    this.loadExpenses();
  }
 
  // Initialize the expense form
  initExpenseForm(): void {
    const category = new FormControl(null, Validators.required);
    this.expenseForm = this.fb.group({
      category: category, // Declare as a FormControl
      amount: [null, [Validators.required, Validators.min(0)]],
      date: [null, Validators.required],
    });
  }

  loadExpenses(): void {
    this.expenseService.getAllExpenses().subscribe(
      (response: ExpenseDto[]) => {
        this.expenses = response || [];
        if (this.expenses.length > 0) {
          this.calculateTotalExpenses();
        }
        console.log(this.expenses);
      },
      (error) => {
        console.error('Error fetching expenses:', error);
        // Handle error scenarios appropriately (e.g., show a user-friendly message)
      }
    );
  }

  // Method to add a new expense
// Modify your addExpense method to include the date
addExpense(): void {
  if (this.expenseForm.valid) {
    const newExpense: ExpenseDto = {
      category: this.expenseForm.value.category,
      expenseValue: this.expenseForm.value.amount,
      currency: 'INR',
      date: this.expenseForm.value.date.toISOString(),
      // Add other properties as needed
    };

    this.expenseService.createExpense(newExpense).subscribe(
      (response: ExpenseDto) => {
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
    this.expenseService.getTotalExpenses('INR').subscribe(
      (result: ExpenseTotalDto) => {
        // Handle the result
        this.totalExpenses = result.totalExpense;
      },
      (error) => {
        // Handle errors
        console.error('Error fetching total expenses:', error);
      }
    );
  }
}
