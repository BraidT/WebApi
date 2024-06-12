import { Component } from '@angular/core';
import { ParticipantService } from '../../Services/participant.service';
import { BusinessParticipantResponse, PrivateParticipantResponse } from '../../Model/ParticipantResponse';
import { ActivatedRoute, Router } from '@angular/router';
import { PaymentTypeEnum } from '../../Model/PaymentTypeEnum';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-participant',
  templateUrl: './add-participant.component.html',
  styleUrl: './add-participant.component.css'
})
export class AddParticipantComponent {
  
  participantForm: FormGroup;
  participantType: 'private' | 'business' = 'private';
  participantId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private participantService: ParticipantService
  ) {
    this.participantForm = this.fb.group({
      participantType: ['private'],
      privateParticipant: this.fb.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        personalCode: ['', Validators.required],
        paymentType: ['', Validators.required],
        additionalInfo: ['']
      }),
      businessParticipant: this.fb.group({
        name: ['', Validators.required],
        registryCode: ['', Validators.required],
        paymentType: ['', Validators.required],
        additionalInfo: [''],
        personCount: [0, Validators.required]
      })
    });
  }

  ngOnInit(): void {
    this.participantId = this.route.snapshot.paramMap.get('participantId') ? Number(this.route.snapshot.paramMap.get('participantId')) : null;
    this.participantType = this.route.snapshot.paramMap.get('isprivate') === 'true' ? 'private' : 'business';

    if (this.participantId !== null) {
      if (this.participantType === 'private') {
        this.participantService.getPrivateParticipant(this.participantId).subscribe((participant: PrivateParticipantResponse) => {
          this.participantForm.patchValue({ privateParticipant: participant });
        });
      } else {
        this.participantService.getBusinessParticipant(this.participantId).subscribe((participant: BusinessParticipantResponse) => {
          this.participantForm.patchValue({ businessParticipant: participant });
        });
      }
    }
  }

  onParticipantTypeChange(): void {
    this.participantId = null;
  }

  onSubmit(): void {
    if (this.participantForm.get('participantType')?.value === 'private') {
      if (this.participantId !== null) {
        this.participantService.updatePrivateParticipant(this.participantForm.get('privateParticipant')?.value).subscribe(response => {
          console.log('Private participant updated:', response);
          this.router.navigate(['/home']);
        });
      } else {
        this.participantService.addPrivateParticipant(this.participantForm.get('privateParticipant')?.value).subscribe(response => {
          console.log('Private participant saved:', response);
          this.router.navigate(['/home']);
        });
      }
    } else {
      if (this.participantId !== null) {
        this.participantService.updateBusinessParticipant(this.participantForm.get('businessParticipant')?.value).subscribe(response => {
          console.log('Business participant updated:', response);
          this.router.navigate(['/home']);
        });
      } else {
        this.participantService.addBusinessParticipant(this.participantForm.get('businessParticipant')?.value).subscribe(response => {
          console.log('Business participant saved:', response);
          this.router.navigate(['/home']);
        });
      }
    }
  }
}
