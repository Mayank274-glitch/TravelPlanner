// home.component.ts

import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { startWith, map } from 'rxjs/operators';
import { ConfigService } from '../services/config.service';
import { ItineraryService } from '../services/itinerary.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  cityControl = new FormControl();
  cities: string[] = ['City1', 'City2', 'City3']; // Replace with your actual city data
  filteredCities: Observable<string[]>;
  selectedCity: string = '';
  selectedItineraryDates: Date[] = [];

  selectedDate: Date | null = null; // Use Date | null

  constructor(private configService: ConfigService,
    private itineraryService: ItineraryService) {
    this.filteredCities = this.cityControl.valueChanges.pipe(
      startWith(''),
      map((value) => this._filterCities(value))
    );
  }

  private _filterCities(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.cities.filter((city) => city.toLowerCase().includes(filterValue));
  }

  displayFn(city: string): string {
    return city ? city : '';
  }

  setCityAndDates(): void {
    // Perform any necessary validation
    this.selectedCity = this.cityControl.value;
    this.selectedItineraryDates = [this.selectedDate || new Date()]; // Use [this.selectedDate] to handle null
    this.configService.setSelectedCity(this.selectedCity);
    this.configService.setSelectedItineraryDates(this.selectedItineraryDates);
    this.itineraryService.storeCityAndItinerary(this.selectedCity, this.selectedItineraryDates.map(selectedItineraryDates => selectedItineraryDates.toLocaleDateString()))
      .subscribe(
        response => {
          console.log('Data stored successfully:', response);
          // Handle any additional logic or UI updates here
        },
        error => {
          console.error('Error storing data:', error);
          // Handle error scenarios
        }
      );
  }
}
