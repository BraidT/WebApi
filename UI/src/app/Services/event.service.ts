import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EventResponse } from '../Model/EventResponse';



@Injectable({
  providedIn: 'root'
})
export class EventService {
  private apiUrl = 'https://localhost:7014/api/events'; // Update this with your actual API URL

  constructor(private http: HttpClient) { }

  getAllEvents(): Observable<EventResponse[]> {
    return this.http.get<EventResponse[]>(this.apiUrl);
  }
}
