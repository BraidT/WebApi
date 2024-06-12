import { PaymentTypeEnum } from  "./PaymentTypeEnum";

export interface PrivateParticipantResponse {
  id: number;
  firstName: string;
  lastName: string;
  personalCode: string;
  additionalInfo: string;
  paymentType: PaymentTypeEnum;
}

export interface BusinessParticipantResponse {
    id: number;
    name: string;
    registryCode: string;
    additionalInfo: string;
    paymentType: PaymentTypeEnum;
    personCount: number;
  }

  export interface ParticipantSearchResponse {
    privateParticipants: PrivateParticipantResponse[];
    businessParticipants: BusinessParticipantResponse[];
  }

  export interface EventPrivateParticipantResponse{
    id: number;
    eventId: number;
    privateParticipantId: number;
    privateParticipant: PrivateParticipantResponse;
    personalCode: string;
    additionalInfo: string;
    paymentType: PaymentTypeEnum;
  }

  export interface EventBusinessParticipantResponse{
    id: number;
    eventId: number;
    businessPParticipantId: number;
    businessPParticipant: BusinessParticipantResponse;
    personalCode: string;
    additionalInfo: string;
    paymentType: PaymentTypeEnum;
  }

  export interface EventPrivateParticipantRequest{
    id: number | null;
    eventId: number;
    privateParticipantId: number;
    additionalInfo: string;
    paymentType: PaymentTypeEnum;
  }

  export interface EventBusinessParticipantRequest{
    id: number | null;
    eventId: number;
    businessParticipantId: number;
    additionalInfo: string;
    paymentType: PaymentTypeEnum;
    participantCount: number;
  }