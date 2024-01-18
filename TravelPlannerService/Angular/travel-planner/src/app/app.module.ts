import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module'; // Import your routing module
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ExploreComponent } from './explore/explore.component';
import { ItineraryService } from './services/itinerary.service';
import { NotesService } from './services/notes.service';
import { PlacesService } from './services/places.service';
import { ExpensesService } from './services/expenses.service';
import { ConfigService } from './services/config.service';
import { BudgetComponent } from './budget/budget.component';
import { ItineraryComponent } from './itinerary/itinerary.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ItineraryComponent,
    ExploreComponent,
    BudgetComponent,
    // Add your other components here
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    ReactiveFormsModule,
    AppRoutingModule, // Include your routing module here
  ],
  providers: [
    ItineraryService,
    NotesService,
    PlacesService,
    ExpensesService,
    ConfigService,],
  bootstrap: [AppComponent],
})
export class AppModule {}
