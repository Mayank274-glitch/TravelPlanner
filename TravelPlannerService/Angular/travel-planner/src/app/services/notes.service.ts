// notes.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';

@Injectable({
  providedIn: 'root',
})
export class NotesService {
    private apiUrl: string; 

    constructor(private http: HttpClient, private configService: ConfigService) {
        this.apiUrl = this.configService.getApiUrl();
      }
  getAllNotes(): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Notes`);
  }

  createNote(data: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/Notes`, data);
  }

  getNoteDetails(id: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Notes/${id}`);
  }

  updateNote(id: string, data: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/api/Notes/${id}`, data);
  }

  deleteNote(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/api/Notes/${id}`);
  }
}
