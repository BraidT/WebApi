import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EventResponse } from '../Model/EventResponse';
import { BusinessParticipantResponse, PrivateParticipantResponse } from '../Model/ParticipantResponse';

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

  get(eventId: number) : Observable<EventResponse> {
    const url = `${this.apiUrl}/events/${eventId}`;
    return this.http.get<EventResponse>(url)
  }

  createEvent(event: EventResponse): Observable<EventResponse> {
    return this.http.post<EventResponse>(`${this.apiUrl}/events`, event);
  }

  deleteEvent(eventId: number){
    const url = `${this.apiUrl}/events/${eventId}`;
    return this.http.delete<boolean>(url);
  }

  addPrivateParticipant(participant: PrivateParticipantResponse): Observable<any> {
    return this.http.post(`${this.apiUrl}/private-participants`, participant);
  }

  addBusinessParticipant(participant: BusinessParticipantResponse): Observable<any> {
    return this.http.post(`${this.apiUrl}/business-participants`, participant);
  }


}
