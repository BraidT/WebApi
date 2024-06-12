import { Component } from '@angular/core';
import { EventService } from '../../Services/event.service';
import { EventResponse } from '../../Model/EventResponse';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css']
})
export class AddEventComponent {
  eventForm: FormGroup;

  constructor(
    private fb: FormBuilder, 
    private eventService: EventService,
    private router: Router) {
      this.eventForm = this.fb.group({
        name: ['', Validators.required],
        beginTime: ['', [Validators.required, this.futureDateValidator]],
        location: ['', Validators.required],
        additionalInfo: ['']
      });
    }


  futureDateValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const selectedDate = new Date(control.value);
    const now = new Date();
    return selectedDate > now ? null : { 'futureDate': true };
  }

  onSubmit() {
    if (this.eventForm.valid) {
      const event: EventResponse = this.eventForm.value;
      this.eventService.createEvent(event).subscribe(response => {
        this.router.navigate([`/home`]);
      }, error => {
        console.error('Error creating event:', error);
      });
    }
  }
}
