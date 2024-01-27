// config.service.ts
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  private apiUrl = 'https://localhost:5000'; // Replace with your actual backend API URL
  private selectedCity: string = '';
  private selectedItineraryDates: Date[] = [];

  setSelectedCity(city: string): void {
    this.selectedCity = city;
  }

  getSelectedCity(): string {
    return this.selectedCity;
  }

  setSelectedItineraryDates(dates: Date[]): void {
    // Clear previous dates if needed
    this.selectedItineraryDates = [];

    // Add dates to the list
    if (dates.length === 2) {
      const [startDate, endDate] = dates;
      const currentDate = new Date(startDate);

      while (currentDate <= endDate) {
        this.selectedItineraryDates.push(new Date(currentDate));
        currentDate.setDate(currentDate.getDate() + 1);
      }
    } else {
      // Handle the case when dates array is not of length 2
      console.error('Invalid dates array:', dates);
    }
  }

  getSelectedItineraryDates(): Date[] {
    return this.selectedItineraryDates;
  }
  
  getApiUrl(): string {
    return this.apiUrl;
  }
}
