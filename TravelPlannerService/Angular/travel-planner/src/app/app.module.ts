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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatNativeDateModule,MAT_DATE_FORMATS  } from '@angular/material/core';

const MY_DATE_FORMATS = {
  parse: {
    dateInput: 'MM/DD/YYYY',
  },
  display: {
    dateInput: 'MM/DD/YYYY',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

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
    MatDatepickerModule ,
    MatAutocompleteModule ,
    MatNativeDateModule ,
    MatFormFieldModule,
    AppRoutingModule,
    BrowserAnimationsModule, // Include your routing module here
  ],
  providers: [
    ItineraryService,
    NotesService,
    PlacesService,
    ExpensesService,
    ConfigService,
    { provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS },
  ],  
  bootstrap: [AppComponent],
})
export class AppModule {}
