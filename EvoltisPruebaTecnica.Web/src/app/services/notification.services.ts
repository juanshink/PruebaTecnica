import { Injectable } from '@angular/core';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  constructor(private messageService: MessageService) {}

  showSuccess(message: string): void {
    this.messageService.add({ severity: 'success', summary: 'Éxito', detail: message,life: 1000 });
  }

  showError(message: string): void {
    this.messageService.add({ severity: 'error', summary: 'Error', detail: message, life: 1000 });
  }

  showInfo(message: string): void {
    this.messageService.add({ severity: 'info', summary: 'Información', detail: message, life: 1000 });
  }
}