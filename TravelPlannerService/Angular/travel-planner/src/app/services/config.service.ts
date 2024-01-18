// config.service.ts
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ConfigService {
  private apiUrl = 'your-backend-api-url'; // Replace with your actual backend API URL

  getApiUrl(): string {
    return this.apiUrl;
  }
}
