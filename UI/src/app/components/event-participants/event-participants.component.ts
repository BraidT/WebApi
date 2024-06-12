import { Component, OnInit, OnDestroy } from '@angular/core';
import { EventService } from '../../Services/event.service';
import { ParticipantService } from '../../Services/participant.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, Subject, forkJoin, of } from 'rxjs';
import { catchError, debounceTime, map, startWith, switchMap, takeUntil } from 'rxjs/operators';
import { EventResponse } from '../../Model/EventResponse';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { BusinessParticipantResponse, EventBusinessParticipantRequest, EventBusinessParticipantResponse, EventPrivateParticipantRequest, PrivateParticipantResponse } from '../../Model/ParticipantResponse';
import { PaymentTypeEnum } from '../../Model/PaymentTypeEnum';
import { EventParticipationService } from '../../Services/event.participation.service';

@Component({
  selector: 'app-event-participants',
  templateUrl: './event-participants.component.html',
  styleUrls: ['./event-participants.component.css']
})
export class EventParticipantsComponent implements OnInit, OnDestroy {
  event$: Observable<EventResponse> = of();
  private destroy$ = new Subject<void>();
  mergedParticipants: MatTableDataSource<MergedParticipant> = new MatTableDataSource<MergedParticipant>();
  eventId: number = 0;
  participantForm: FormGroup;
  displayedColumns: string[] = ['name', 'code', 'actions'];
  searchControl = new FormControl();
  filteredParticipants: Observable<(PrivateParticipantResponse | BusinessParticipantResponse)[]> = of();

  participantType: 'private' | 'business' = 'private';
  participantId: number | null = null;
  eventParticipantId: number | null = null;

  privateParticipant: PrivateParticipantResponse = {
    id: 0,
    firstName: '',
    lastName: '',
    personalCode: '',
    additionalInfo: '',
    paymentType: PaymentTypeEnum.None
  };

  businessParticipant: BusinessParticipantResponse = {
    id: 0,
    name: '',
    registryCode: '',
    additionalInfo: '',
    personCount: 0,
    paymentType: PaymentTypeEnum.None
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private eventService: EventService,
    private participantService: ParticipantService,
    private eventParticipationService: EventParticipationService,
    private fb: FormBuilder
  ) {
    this.participantForm = this.fb.group({
      paymentType: ['', Validators.required],
      additionalInfo: [''],
      personCount: [1, [Validators.required, Validators.min(1)]]
    });
  }

  ngOnInit(): void {
    this.eventId = Number(this.route.snapshot.paramMap.get('eventId'));
    this.event$ = this.eventService.get(this.eventId);
    this.event$.subscribe(event => {
      console.log('Event data:', event);
    });
    this.loadParticipants(this.eventId);
    this.filteredParticipants = this.searchControl.valueChanges.pipe(
      startWith(''),
      debounceTime(500),
      switchMap(value => 
        this.participantService.searchParticipants(value).pipe(
          map(response => [...response.privateParticipants, ...response.businessParticipants]),
          catchError(() => { console.log('some error'); return of([]); }),
          takeUntil(this.destroy$) 
        )
      )
    );
  }

  loadParticipants(eventId: number): void {
    forkJoin({
      private: this.participantService.getPrivateParticipants(eventId),
      business: this.participantService.getBusinessParticipants(eventId)
    }).pipe(
      map(response => {
        const privateParticipants = response.private.map(privateParticipant => ({
          id: privateParticipant.id,
          name: `${privateParticipant.firstName} ${privateParticipant.lastName}`,
          code: privateParticipant.personalCode,
          isPrivate: true
        }));

        const businessParticipants = response.business.map(businessParticipant => ({
          id: businessParticipant.id,
          name: businessParticipant.name,
          code: businessParticipant.registryCode,
          isPrivate: false
        }));

        return [...privateParticipants, ...businessParticipants];
      })
    ).subscribe(mergedParticipants => {
      this.mergedParticipants.data = mergedParticipants;
    });
  }

  getMergedParticipants(): MergedParticipant[] {
    return this.mergedParticipants.data;
  }

  viewParticipant(participant: any): void {
    this.router.navigate([`/participant/${participant.id}/${participant.isPrivate}`]);
  }

  deleteParticipant(id: number): void {
    if (this.participantType === 'private'){
      this.eventParticipationService.deleteEventPrivateParticipant(id).subscribe(() => {
        this.loadParticipants(this.eventId);
      });
    }else {
      this.eventParticipationService.deleteEventBusinessParticipant(id).subscribe(() => {
        this.loadParticipants(this.eventId);
      });
    }
  }

  displayParticipant(participant: PrivateParticipantResponse | BusinessParticipantResponse): string {
    if ('name' in participant) {
      return participant.name;
    } else {
      return `${participant.firstName} ${participant.lastName}`;
    }
  }

  onSubmit(): void {
    if (this.participantType === 'private') {
      if (this.eventParticipantId !== null) {
        this.eventParticipationService.updatePrivateParticipant(this.createEventPrivateParticipantRequest()).subscribe(response => {
          console.log('Private participant updated:', response);
          this.loadParticipants(this.eventId);
        });
      } else {
        this.eventParticipationService.createPrivateParticipant(this.createEventPrivateParticipantRequest()).subscribe(response => {
          console.log('Private participant saved:', response);
          this.loadParticipants(this.eventId);
        });
      }
    } else {
      if (this.eventParticipantId !== null) {
        this.eventParticipationService.updateBusinessParticipant(this.createEventBusinessParticipantRequest()).subscribe(response => {
          console.log('Business participant updated:', response);
          this.loadParticipants(this.eventId);
        });
      } else {
        this.eventParticipationService.createBusinessParticipant(this.createEventBusinessParticipantRequest()).subscribe(response => {
          console.log('Business participant saved:', response);
          this.loadParticipants(this.eventId);
        });
      }
    }
  }

  createEventPrivateParticipantRequest() : EventPrivateParticipantRequest{
    const newParticipantRequest: EventPrivateParticipantRequest = {
      id: this.eventParticipantId,
      privateParticipantId: this.privateParticipant.id,
      eventId: this.eventId,
      additionalInfo: this.privateParticipant.additionalInfo,
      paymentType: this.privateParticipant.paymentType
    }
    return newParticipantRequest;
  }

  createEventBusinessParticipantRequest(){
    const newParticipantRequest: EventBusinessParticipantRequest = {
      id: this.eventParticipantId,
      businessParticipantId: this.businessParticipant.id,
      eventId: this.eventId,
      additionalInfo: this.businessParticipant.additionalInfo,
      paymentType: this.businessParticipant.paymentType,
      participantCount: this.businessParticipant.personCount
    }
    return newParticipantRequest;
  }

  onParticipantTypeChange(): void {
    this.participantId = null;
  }

  back(): void {
    this.router.navigate(['/home']);
  }

  onParticipantSelected(participant: PrivateParticipantResponse | BusinessParticipantResponse): void {
    if ('name' in participant) {
      this.participantType = 'business';
      this.participantId = participant.id;
      this.businessParticipant = participant;
      this.participantForm.patchValue({
        paymentType: participant.paymentType,
        additionalInfo: participant.additionalInfo,
        personCount: participant.personCount
      });
    } else {
      this.participantType = 'private';
      this.participantId = participant.id;
      this.privateParticipant = participant;
      this.participantForm.patchValue({
        paymentType: participant.paymentType,
        additionalInfo: participant.additionalInfo,
        personCount: 1
      });
    }
  }

  ngOnDestroy() {
    this.destroy$.next();
    this.destroy$.complete();
  }
}

export interface MergedParticipant {
  id: number;
  name: string;
  code: string;
  isPrivate: boolean;
}
