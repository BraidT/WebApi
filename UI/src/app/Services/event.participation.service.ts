import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { EventBusinessParticipantRequest, EventBusinessParticipantResponse, EventPrivateParticipantRequest, EventPrivateParticipantResponse } from "../Model/ParticipantResponse";

@Injectable({
    providedIn: 'root'
  })
  export class EventParticipationService {
    private apiUrl = 'https://localhost:7014/api'; // Update this with your actual API URL
  
    constructor(private http: HttpClient) { }

    getEventParticipant(id: number): Observable<EventPrivateParticipantResponse | EventBusinessParticipantResponse> {
      return this.http.get<EventPrivateParticipantResponse | EventBusinessParticipantResponse>(`${this.apiUrl}/EventParticipation/private/${id}`);
    }

    getEventPrivateParticipant(id: number): Observable<EventPrivateParticipantResponse> {
      return this.http.get<EventPrivateParticipantResponse>(`${this.apiUrl}/EventParticipation/private/${id}`);
    }

    getEventBusinessParticipant(id: number): Observable<EventBusinessParticipantResponse> {
      return this.http.get<EventBusinessParticipantResponse>(`${this.apiUrl}/EventParticipation/business/${id}`);
    }
  
    getBusinessParticipant(participant: EventBusinessParticipantRequest): Observable<any> {
      return this.http.post(`${this.apiUrl}/EventParticipation/Business`, participant);
    }


    createPrivateParticipant(participant: EventPrivateParticipantRequest): Observable<any> {
      return this.http.post(`${this.apiUrl}/EventParticipation/Private`, participant);
    }
  
    createBusinessParticipant(participant: EventBusinessParticipantRequest): Observable<any> {
      return this.http.post(`${this.apiUrl}/EventParticipation/Business`, participant);
    }

    updatePrivateParticipant(participant: EventPrivateParticipantRequest): Observable<any> {
      return this.http.put(`${this.apiUrl}/EventParticipation/Private`, participant);
    }
  
    updateBusinessParticipant(participant: EventBusinessParticipantRequest): Observable<any> {
      return this.http.put(`${this.apiUrl}/EventParticipation/Business`, participant);
    }

    deleteEventPrivateParticipant(eventPrivateParticipantId: number){
        const url = `${this.apiUrl}/EventParticipation/private/deleteEventParticipant/${eventPrivateParticipantId}`;
        return this.http.delete<boolean>(url);
    }

    deleteEventBusinessParticipant(eventBusinessParticipantId: number){
        const url = `${this.apiUrl}/EventParticipation/business/deleteEventParticipant/${eventBusinessParticipantId}`;
        return this.http.delete<boolean>(url);
    }
  }