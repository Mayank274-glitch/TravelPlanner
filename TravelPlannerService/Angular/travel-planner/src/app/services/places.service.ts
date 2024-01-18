// places.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class PlacesService {
    private apiUrl: string; 

    constructor(private http: HttpClient, private configService: ConfigService) {
        this.apiUrl = this.configService.getApiUrl();
      }
  getAllPlaces(): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Places`);
  }

  createPlace(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/Places`, data);
  }

  getPlaceDetails(id: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Places/${id}`);
  }

  updatePlace(id: string, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/api/Places/${id}`, data);
  }

  deletePlace(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/api/Places/${id}`);
  }

  searchPlaces(city: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Places/search?city=${city}`);
  }

  getTopPlaces(city: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Places/top-10?city=${city}`);
  }
}
