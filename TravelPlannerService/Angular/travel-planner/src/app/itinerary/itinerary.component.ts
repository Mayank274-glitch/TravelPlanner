// itinerary.component.ts
import { Component } from '@angular/core';
import { ItineraryService } from '../services/itinerary.service';

@Component({
  selector: 'app-itinerary',
  templateUrl: './itinerary.component.html',
  styleUrls: ['./itinerary.component.css']
})
export class ItineraryComponent {
  itineraryDates: Date[] = [];
  expandedDate: Date | null = null;
  showAddCityPanel: boolean = false;
  citiesForDate: string[] = [];


  constructor(private itineraryService: ItineraryService) {
    
    // Initialize itineraryDates with sample dates (replace with actual data)
    this.itineraryDates = [new Date('2024-01-01'), new Date('2024-01-02'), new Date('2024-01-03')];
  }

  // Method to toggle the expand/collapse of a date panel
  toggleDatePanel(date: Date): void {
    if (this.expandedDate && this.expandedDate.getTime() === date.getTime()) {
      this.expandedDate = null; // Collapse the panel if it's already expanded
    } else {
      this.expandedDate = date;
    }
  }

  // Method to open the add city panel
  openAddCityPanel(): void {
    this.showAddCityPanel = true;
  }

  // Method to close the add city panel
  closeAddCityPanel(): void {
    this.showAddCityPanel = false;
  }

  // itinerary.component.ts
getCitiesForDate(date: string): void {
  this.itineraryService.getCitiesForDate(date).subscribe(
    (cities: string[]) => {
      this.citiesForDate = cities;
    },
    (error) => {
      console.error('Error fetching cities for date:', error);
      // Handle error scenarios
    }
  );
}

}
