/* home.component.ts */
import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { ConfigService } from '../services/config.service';
import { ItineraryService } from '../services/itinerary.service';
import { Router } from '@angular/router';
import { SocialAuthService, GoogleLoginProvider,SocialUser } from 'angularx-social-login';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  backgroundImageUrl = 'assets/CoverPic.jpg';
  cityControl = new FormControl();
  cities: string[] = ['City1', 'City2', 'City3'];
  filteredCities: Observable<string[]>;
  formGroup: FormGroup;
  user: SocialUser | null = null;
  loggedIn: boolean = false;

  constructor(
    private configService: ConfigService,
    private router: Router,
    private itineraryService: ItineraryService,
    private fb: FormBuilder,
    private authService: SocialAuthService
  ) {
    this.filteredCities = this.cityControl.valueChanges.pipe(
      startWith(''),
      map((value) => this._filterCities(value))
    );

    this.formGroup = this.fb.group({
      city: this.cityControl,
      startDate: new FormControl(),
      endDate: new FormControl(),
    });
  }

  ngOnInit(): void {
    this.authService.authState.subscribe((user) => {
      this.user = user;
      this.loggedIn = user != null;
    });
  }

  signInWithGoogle(): void {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  signOut(): void {
    this.authService.signOut();
  }

  private _filterCities(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.cities.filter((city) => city.toLowerCase().includes(filterValue));
  }

  get startDateControl() {
    return this.formGroup.get('startDate') as FormControl;
  }

  get endDateControl() {
    return this.formGroup.get('endDate') as FormControl;
  }

  setCityAndDates(): void {
    if (!this.user) {
      // User not logged in, redirect to login or show a login prompt
      console.log('User not logged in. Please log in to set city and dates.');
      // Add your logic to redirect or show login prompt here
      return;
    }

    const { city, startDate, endDate } = this.formGroup.value;

    this.configService.setSelectedCity(city);
    this.configService.setSelectedItineraryDates([
      startDate || new Date(),
      endDate || new Date(),
    ]);

    const data = {
      city: city,
      startDate: startDate ? startDate.toISOString() : '',
      endDate: endDate ? endDate.toISOString() : '',
    };

    this.itineraryService.storeCityAndItinerary(data).subscribe(
      (response) => {
        console.log('Data stored successfully:', response);
        // Handle any additional logic or UI updates here
        this.router.navigate(['/dashboard']);
      },
      (error) => {
        console.error('Error storing data:', error);
        // Handle error scenarios
      }
    );
  }
}
