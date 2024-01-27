// itinerary.component.ts
import { Component } from '@angular/core';
import { ItineraryService } from '../services/itinerary.service';
import { ConfigService } from '../services/config.service';
import { PlacesService } from '../services/places.service';
import { NotesService } from '../services/notes.service';
import { NoteDto } from '../models/notes.dto';

@Component({
  selector: 'app-itinerary',
  templateUrl: './itinerary.component.html',
  styleUrls: ['./itinerary.component.css']
})
export class ItineraryComponent {
  editingNoteId: number | null = null;
  itineraryDates: Date[] = [];
  expandedDate: Date | null = null;
  citiesForDate: string[] = [];
  placesByDate: { [key: number]: any[] } = {}; // Dictionary to store places for each date
  places: any[] = []; // Adjust this based on your place model
  selectedPlace: any = null; // Placeholder for the selected place
  searchQueries: { [key: number]: string } = {}; // Dictionary to store search queries for each date
  noteText: string = '';
  notesByDate: { [key: number]: any[] } = {};
  noteTextByDate: { [key: number]: string } = {}; // Dictionary to store note text for each date
  
  constructor(
    private itineraryService: ItineraryService,
    private placesService: PlacesService,
    private notesService: NotesService,
    private configService: ConfigService
  ) {
    // Initialize itineraryDates with sample dates (replace with actual data)
    this.itineraryDates = this.configService.getSelectedItineraryDates();
    console.log('dates are  :', this.itineraryDates);
  }

  // Method to toggle the expand/collapse of a date panel
  toggleDatePanel(date: Date): void {
    if (this.expandedDate && this.expandedDate.getTime() === date.getTime()) {
      this.expandedDate = null; // Collapse the panel if it's already expanded
    } else {
      this.expandedDate = date;
    }
  }

  setPlacesForDate(date: Date, places: any[]): void {
    this.placesByDate[date.getTime()] = places;
  }

  getPlacesForDate(date: Date): any[] {
    return this.placesByDate[date.getTime()] || [];
  }

  getSearchQuery(date: Date): string {
    return this.searchQueries[date.getTime()] || '';
  }

  setSearchQuery(date: Date, query: string): void {
    this.searchQueries[date.getTime()] = query;
  }

  getCitiesForDate(date: string): void {
       const startDate = date;
    const endDate = date; // Assuming you want to get details for a single date
  
    this.itineraryService.getCitiesForDate(date,endDate).subscribe(
      (cities: string[]) => {
        this.citiesForDate = cities;
      },
      (error) => {
        console.error('Error fetching cities for date:', error);
        // Handle error scenarios
      }
    );
  }

  searchPlaces(date: Date): void {
    const query = this.getSearchQuery(date).trim();
    if (query !== '') {
      this.placesService.searchPlaces(query).subscribe(
        (response) => {
          this.setPlacesForDate(date, response || []);
        },
        (error) => {
          console.error('Error searching places:', error);
          // Handle error scenarios
        }
      );
    }
  }

  selectPlace(place: any): void {
    this.selectedPlace = place;
  }

  addPlaceToItinerary(date: Date, place: any): void {
    const startDate = date.toISOString();
    const endDate = date.toISOString(); // Assuming you want to get details for a single date
  
    this.itineraryService.getCitiesForDate(startDate, endDate).subscribe(
      (itineraryDetails) => {
        const itineraryId = itineraryDetails.id; // Replace 'id' with the actual property holding the itineraryId
        this.itineraryService.addPlaceToItinerary(itineraryId, place).subscribe(
          (response) => {
            console.log('Place added to itinerary:', response);
            // Optionally, update the local places array or refresh the search
            this.searchPlaces(date);
          },
          (error) => {
            console.error('Error adding place to itinerary:', error);
            // Handle error scenarios
          }
        );
      },
      (error) => {
        console.error('Error fetching itinerary details:', error);
        // Handle error scenarios
      }
    );
  }

  savePlace(date: Date): void {
    if (this.selectedPlace) {
      const existingPlace = this.places.find(
        (place) => place.googlePlaceId === this.selectedPlace.googlePlaceId
      );
  
      if (!existingPlace) {
        // If the place is not in the itinerary, add it
        this.placesService.createPlace(this.selectedPlace).subscribe(
          (response) => {
            console.log('Place added successfully:', response);
            // Update the itinerary with the new place
            this.addPlaceToItinerary(date, response);
          },
          (error) => {
            console.error('Error adding place:', error);
            // Handle error scenarios
          }
        );
      } else {
        // If the place already exists, update it
        this.placesService.updatePlace(existingPlace.id, this.selectedPlace).subscribe(
          (response) => {
            console.log('Place updated successfully:', response);
            // Update the itinerary with the updated place
            this.addPlaceToItinerary(date, response);
          },
          (error) => {
            console.error('Error updating place:', error);
            // Handle error scenarios
          }
        );
      }
    }
  }

  setNotesForDate(date: Date, notes: any[]): void {
    this.notesByDate[date.getTime()] = notes;
  }

  getNotesForDate(date: Date): any[] {
    return this.notesByDate[date.getTime()] || [];
  }

  getNoteTextForDate(date: Date): string {
    return this.noteTextByDate[date.getTime()] || '';
  }
  
  editNoteDate(date: Date, note: any): void {
    const noteDate = new Date(date);
    const editedNoteText = this.noteTextByDate[noteDate.getTime()];

    if (editedNoteText.trim() !== '') {
      const updatedNote: NoteDto = {
        id: note.id,
        title: '', // Assuming title is part of your NoteDto
        content: editedNoteText,
        date: date,
      };

      this.notesService.updateNoteByDate(noteDate, note.id, updatedNote).subscribe(
        (response) => {
          console.log('Note updated successfully:', response);
          // Optionally, update the local notes array or refresh the display
          this.setNotesForDate(date, this.getUpdatedNotes(date, response));
          this.editingNoteId = null; // Reset editing state
        },
        (error) => {
          console.error('Error updating note:', error);
          // Handle error scenarios
        }
      );
    } else {
      console.log('Note content cannot be empty.');
    }
  }

  // Helper method to update the local notes array
  private getUpdatedNotes(date: Date, updatedNote: any): any[] {
    const existingNotes = this.getNotesForDate(date);
    const updatedNoteIndex = existingNotes.findIndex((note) => note.id === updatedNote.id);

    if (updatedNoteIndex !== -1) {
      existingNotes[updatedNoteIndex] = updatedNote;
    }

    return existingNotes;
  }
  

  resetNoteForm(date: Date): void {
    this.noteTextByDate[date.getTime()] = ''; // Clear the note text after saving or canceling
    this.editingNoteId = null;
  }

  deleteNote(date: Date, noteId: number): void {
    this.notesService.deleteNote(noteId.toString()).subscribe(
      () => {
        console.log('Note deleted successfully.');
        // Remove the deleted note from the local array
        this.setNotesForDate(date, this.getNotesForDate(date).filter(n => n.id !== noteId));
      },
      (error) => {
        console.error('Error deleting note:', error);
      }
    );
  }

  setNoteTextForDate(date: Date, text: string): void {
    this.noteTextByDate[date.getTime()] = text;
  }

  saveNote(date: Date): void {
    const noteText = this.noteTextByDate[date.getTime()];
  
    if (noteText.trim() !== '') {
      const noteDto: NoteDto = {
        title: '',
        content: noteText,
        date: date,
      };
  
      this.notesService.createNoteByDate(noteDto).subscribe(
        (response) => {
          console.log('Note added successfully:', response);
          this.setNotesForDate(date, [...this.getNotesForDate(date), response]);
          this.noteTextByDate[date.getTime()] = ''; // Clear the note text after saving
        },
        (error) => {
          console.error('Error adding note:', error);
        }
      );
    }
  }
  

  }

