import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AddEventComponent } from './components/add-event/add-event.component';
import { EventParticipantsComponent } from './components/event-participants/event-participants.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'add-event', component: AddEventComponent },
  { path: 'participants/:eventId', component: EventParticipantsComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' } // Redirect to home by default
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
