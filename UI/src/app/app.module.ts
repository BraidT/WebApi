import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { LayoutComponent } from './components/layout/layout.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { AddEventComponent } from './components/add-event/add-event.component';
import { FormsModule } from '@angular/forms';
import { EventParticipantsComponent } from './components/event-participants/event-participants.component'; 


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LayoutComponent,
    AddEventComponent,
    EventParticipantsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    MatButtonModule,
    FormsModule
  ],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
