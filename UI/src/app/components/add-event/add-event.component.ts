import { Component } from '@angular/core';
import { EventService } from '../../Services/event.service';
import { EventResponse } from '../../Model/EventResponse';

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css']
})
export class AddEventComponent {
  event: EventResponse = {
    id: 0,
    name: '',
    beginTime: new Date(),
    location: '',
    additionalInfo: ''
  };

  constructor(private eventService: EventService) {}

  saveEvent() {
    this.eventService.createEvent(this.event).subscribe(response => {
      console.log('Event created:', response);
      // Optionally reset the form or handle response
    }, error => {
      console.error('Error creating event:', error);
    });
  }
}
