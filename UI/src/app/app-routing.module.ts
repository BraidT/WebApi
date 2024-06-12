import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AddEventComponent } from './components/add-event/add-event.component';
import { EventParticipantsComponent } from './components/event-participants/event-participants.component';
import { AddParticipantComponent } from './components/add-participant/add-participant.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'event', component: AddEventComponent },
  { path: 'events/:eventId', component: EventParticipantsComponent },
  { path: 'participants/:eventId/:eventParticipantId', component: EventParticipantsComponent },
  { path: 'participants/:eventId', component: EventParticipantsComponent },
  { path: 'participant', component: AddParticipantComponent},
  { path: 'participant/:participantId/:isprivate', component: AddParticipantComponent},
  { path: '', redirectTo: '/home', pathMatch: 'full' } 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
