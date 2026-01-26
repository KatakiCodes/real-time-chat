import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-confirmation-modal',
  standalone: false,
  templateUrl: './confirmation-modal.html',
  styleUrl: './confirmation-modal.scss',
})
export class ConfirmationModal {
  @Input() title: string = 'Confirmar ação';
  @Input() message: string = '';
  @Input() errorResult: string = '';
  @Input() confirmationCode: string = '';
  @Input() isDanger: boolean = false;
  @Input() userInput: string = '';

  @Output() ConfirmActionModal = new EventEmitter<boolean>();
  @Output() close = new EventEmitter<void>();

  getInputValue(value: string) {
    this.userInput = value;
  }
  onConfirm(): boolean {
    if (this.confirmationCode) {
      if (this.userInput === this.confirmationCode) {
        return true;
      } else {
        this.errorResult = 'Código de confirmação incorreto. Tente novamente.';
        return false;
      }
    }
    else {
      return false;
    }
  }
}