import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EventResponse } from '../Model/EventResponse';



@Injectable({
  providedIn: 'root'
})
export class EventService {
  private apiUrl = 'https://localhost:7014/api'; // Update this with your actual API URL

  constructor(private http: HttpClient) { }

  getAllEvents(): Observable<EventResponse[]> {
    const url = `${this.apiUrl}/events`;
    return this.http.get<EventResponse[]>(url);
  }

  createEvent(event: EventResponse): Observable<EventResponse> {
    return this.http.post<EventResponse>(this.apiUrl, event);
  }

  deleteEvent(eventId: number){
    const url = `${this.apiUrl}events/${eventId}`;
    return this.http.delete<boolean>(this.apiUrl);
  }
}
