// explore.component.ts
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { PlacesService } from '../services/places.service';
import { PlaceResult } from '../models/place-result.model';
import { ConfigService } from '../services/config.service';

@Component({
  selector: 'app-explore',
  templateUrl: './explore.component.html',
  styleUrls: ['./explore.component.css']
})
export class ExploreComponent {
  @Input() selectedCity: string = '';
  @Input() selectedItineraryDates: Date[] = []; // Input binding for itinerary dates
  @Output() addPlaceToItinerary: EventEmitter<any> = new EventEmitter<any>();

  topPlaces: PlaceResult[] = [];
  showAddPopup: boolean = false;
  selectedPlace: PlaceResult | null = null;
  selectedDatetime: string = '';

  constructor(private placesService: PlacesService, private configService: ConfigService) {}

  // Method to fetch top places around the selected city from the API
  fetchTopPlaces(): void {
    this.placesService.getTopPlaces(this.selectedCity).subscribe(
      (response: PlaceResult[]) => {
        this.topPlaces = response || [];
      },
      (error) => {
        console.error('Error fetching top places:', error);
        // Handle error scenarios
      }
    );
  }

  // Method to open the add place popup
  openAddPopup(place: PlaceResult): void {
    this.selectedPlace = place;
    this.showAddPopup = true;
  }

  // Method to close the add place popup
  closeAddPopup(): void {
    this.showAddPopup = false;
    this.selectedPlace = null;
    // No need to clear selectedDatetime if you want to retain the value
  }

  // Method to handle adding a place to the itinerary
  handleAddPlaceToItinerary(): void {
    if (this.selectedDatetime) {
      this.addPlaceToItinerary.emit({
        place: this.selectedPlace,
        datetime: this.selectedDatetime
      });
      this.closeAddPopup();
    }
  }
}
