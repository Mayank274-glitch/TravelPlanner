// config.service.ts
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  private apiUrl = 'https://localhost:7254'; // Replace with your actual backend API URL
  private selectedCity: string = '';
  private selectedItineraryDates: Date[] = [];

  setSelectedCity(city: string): void {
    this.selectedCity = city;
  }

  getSelectedCity(): string {
    return this.selectedCity;
  }

  setSelectedItineraryDates(dates: Date[]): void {
    this.selectedItineraryDates = dates;
  }

  getSelectedItineraryDates(): Date[] {
    return this.selectedItineraryDates;
  }
  
  getApiUrl(): string {
    return this.apiUrl;
  }
}
