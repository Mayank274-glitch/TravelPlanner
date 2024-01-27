// notes.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConfigService } from './config.service';
import { NoteDto } from '../models/notes.dto';

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

  createNote(data: NoteDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/Notes`, data);
  }

  getNoteDetails(id: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/api/Notes/${id}`);
  }

  updateNote(id: string, data: NoteDto): Observable<any> {
    return this.http.put(`${this.apiUrl}/api/Notes/${id}`, data);
  }

  deleteNote(id: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/api/Notes/${id}`);
  }

  getNotesByDate(date: Date): Observable<any> {
    const formattedDate = date.toISOString().split('T')[0];
    return this.http.get(`${this.apiUrl}/api/Notes/NotesByDate/${formattedDate}`);
  }

  createNoteByDate(noteDto: NoteDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/Notes/by-date`, noteDto);
  }

  getNoteDetailsByDate(date: Date, id: number): Observable<any> {
    const formattedDate = date.toISOString().split('T')[0];
    return this.http.get(`${this.apiUrl}/api/Notes/NotesByDate/${formattedDate}/${id}`);
  }

  updateNoteByDate(date: Date, id: number, noteDto: NoteDto): Observable<any> {
    const formattedDate = date.toISOString().split('T')[0];
    return this.http.put(`${this.apiUrl}/api/Notes/NotesByDate/${formattedDate}/${id}`, noteDto);
  }

  deleteNoteByDate(date: Date, id: number): Observable<any> {
    const formattedDate = date.toISOString().split('T')[0];
    return this.http.delete(`${this.apiUrl}/api/Notes/NotesByDate/${formattedDate}/${id}`);
  }
}
