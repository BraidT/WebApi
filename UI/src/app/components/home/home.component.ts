import { Component } from '@angular/core';
import { EventResponse } from '../../Model/EventResponse';
import { EventService } from '../../Services/event.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  futureEvents: EventResponse[] = [];
  pastEvents: EventResponse[] = [];
  displayedColumns: string[] = ['name', 'date', 'actions'];
  
  constructor(private eventService: EventService, private router: Router) {}

  ngOnInit(): void {
    this.loadEvents();
  }

  loadEvents(): void {
    this.eventService.getAllEvents().subscribe(events => {
      const now = new Date();
      this.futureEvents = events.filter(event => new Date(event.beginTime) > now);
      this.pastEvents = events.filter(event => new Date(event.beginTime) <= now);
    });
  }

  deleteEvent(eventId: number): void {
    this.eventService.deleteEvent(eventId).subscribe(() => {
      console.log(`Delete event with ID: ${eventId}`);
      this.loadEvents();
    });
  }

  navigateToAddEvent(): void {
    this.router.navigate(['/event']);
  }

  viewParticipants(eventId: number): void {
    this.router.navigate([`/participants/${eventId}`]);
  }
}
