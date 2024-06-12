import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusinessParticipantResponse, PrivateParticipantResponse, ParticipantSearchResponse, EventPrivateParticipantResponse, EventBusinessParticipantResponse } from '../Model/ParticipantResponse';

@Injectable({
  providedIn: 'root'
})
export class ParticipantService {
  private apiUrl = 'https://localhost:7014/api'; 

  constructor(private http: HttpClient) { }

  getPrivateParticipant(participantId: Number) : Observable<PrivateParticipantResponse>{
    return this.http.get<PrivateParticipantResponse>(`${this.apiUrl}/participant/private/${participantId}`);
  }

  getBusinessParticipant(participantId: Number) : Observable<BusinessParticipantResponse>{
    return this.http.get<BusinessParticipantResponse>(`${this.apiUrl}/participant/business/${participantId}`);
  }

  addPrivateParticipant(participant: PrivateParticipantResponse): Observable<any> {
    return this.http.post(`${this.apiUrl}/participant/private`, participant);
  }

  addBusinessParticipant(participant: BusinessParticipantResponse): Observable<any> {
    return this.http.post(`${this.apiUrl}/participant/business`, participant);
  }

  updatePrivateParticipant(participant: PrivateParticipantResponse): Observable<any> {
    return this.http.put(`${this.apiUrl}/participant/private`, participant);
  }

  updateBusinessParticipant(participant: BusinessParticipantResponse): Observable<any> {
    return this.http.put(`${this.apiUrl}/participant/private`, participant);
  }

  getPrivateParticipants(eventId: number):Observable<EventPrivateParticipantResponse[]>{
    const url = `${this.apiUrl}/participant/private/getbyevent/${eventId}`;
    return this.http.get<EventPrivateParticipantResponse[]>(url);
  }

  getBusinessParticipants(eventId: number):Observable<EventBusinessParticipantResponse[]>{
    const url = `${this.apiUrl}/participant/business/getbyevent/${eventId}`;
    return this.http.get<EventBusinessParticipantResponse[]>(url);
  }

  searchParticipants(searchTerm: string): Observable<ParticipantSearchResponse> {
    return this.http.get<ParticipantSearchResponse>(`${this.apiUrl}/participant/search?searchTerm=${searchTerm}`);
  }
}