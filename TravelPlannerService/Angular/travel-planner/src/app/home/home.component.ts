// home.component.ts
import { Component, OnInit } from '@angular/core';
import { FormControl, FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { ConfigService } from '../services/config.service';
import { ItineraryService } from '../services/itinerary.service';
import { AuthService } from '../services/auth.service';

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
  user: any; // Assuming you have a user object, update the type accordingly

  constructor(
    private configService: ConfigService,
    private itineraryService: ItineraryService,
    private authService: AuthService,
    private fb: FormBuilder
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
    this.authService.loggedIn$.subscribe((loggedIn) => {
      this.user = loggedIn;
    });
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
        // Redirect to the dashboard or any desired page
        // For demonstration purposes, redirect to the dashboard
        this.authService.login();
      },
      (error) => {
        console.error('Error storing data:', error);
        // Handle error scenarios
      }
    );
  }

  // Use AuthService's signOut method
  signOut(): void {
    this.authService.signOut();
  }
}
