import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LayoutComponent } from './components/layout/layout.component';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatRadioModule } from '@angular/material/radio';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';

import { AddEventComponent } from './components/add-event/add-event.component';
import { FormsModule } from '@angular/forms';
import { EventParticipantsComponent } from './components/event-participants/event-participants.component';
import { ParticipantListComponent } from './components/participant-list/participant-list.component';
import { AddParticipantComponent } from './components/add-participant/add-participant.component'; 



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LayoutComponent,
    AddEventComponent,
    EventParticipantsComponent,
    ParticipantListComponent,
    AddParticipantComponent,
    AddParticipantComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatToolbarModule,
    MatNativeDateModule,
    MatListModule,
    MatCardModule,
    MatTableModule,
    MatAutocompleteModule,
    MatRadioModule,
    MatDividerModule,
    MatSelectModule,
    BrowserAnimationsModule
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
