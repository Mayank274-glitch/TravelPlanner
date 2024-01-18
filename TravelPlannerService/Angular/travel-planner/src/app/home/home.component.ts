// home.component.ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  cities: string[] = ['New York', 'Paris', 'Tokyo'];
  selectedCity: string = '';
  showCoverPic: boolean = false;

  // Example method to set the selected city
  setCity(city: string): void {
    this.selectedCity = city;
  }

  // Example method to toggle cover pic visibility
  toggleCoverPic(): void {
    this.showCoverPic = !this.showCoverPic;
  }
}
