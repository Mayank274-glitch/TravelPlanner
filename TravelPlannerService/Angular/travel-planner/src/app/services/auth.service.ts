// auth.service.ts
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loggedInSubject = new BehaviorSubject<boolean>(false);

  // Expose the authentication status as an observable
  loggedIn$ = this.loggedInSubject.asObservable();

  constructor(private router: Router) {}

  // Method to set the authentication status
  setLoggedIn(value: boolean) {
    this.loggedInSubject.next(value);
  }

  // Simulate a login
  login() {
    // Perform any authentication logic (e.g., API calls)
    // For demonstration purposes, we set a dummy user here
    const user = { id: 1, username: 'demoUser' };

    // Perform additional actions if needed

    // Set the authentication status to true
    this.setLoggedIn(true);

    // Redirect to the dashboard or any desired page
    this.router.navigate(['/dashboard']);
  }

  // Method to sign out
  signOut() {
    // Perform any additional cleanup or API calls related to sign out

    // Redirect to the home page after sign-out
    this.router.navigate(['/home']);

    // Set the authentication status to false
    this.setLoggedIn(false);
  }
}
