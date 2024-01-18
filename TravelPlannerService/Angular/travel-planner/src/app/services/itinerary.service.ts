// itinerary.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class ItineraryService {
    private apiUrl: string; 

    constructor(private http: HttpClient, private configService: ConfigService) {
        this.apiUrl = this.configService.getApiUrl();
      }

  getAllItineraries(): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Itinerary`);
  }

  createItinerary(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/Itinerary`, data);
  }

  getItineraryDetails(id: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Itinerary/${id}`);
  }

  updateItinerary(id: string, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/api/Itinerary/${id}`, data);
  }

  deleteItinerary(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/api/Itinerary/${id}`);
  }
  
  addPlaceToItinerary(itineraryId: string, placeData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/Itinerary/${itineraryId}/places`, placeData);
  }

  getCitiesForDate(date: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Itinerary/cities?date=${date}`);
  }
}
