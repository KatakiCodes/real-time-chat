import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-edit-chat',
  standalone: false,
  templateUrl: './edit-chat.html',
  styleUrl: './edit-chat.scss',
})
export class EditChat {
  @Input() title: string = '';
  @Input() message: string = '';
  @Input() errorResult: string = '';
  @Input() confirmationCode: string = '';
  @Input() isDanger: boolean = false;
  @Input() userInput: string = '';
  @Input() userInputCode: string = '';

  @Output() ConfirmActionModal = new EventEmitter<boolean>();
  @Output() close = new EventEmitter<void>();

  getInputValue(value: string) {
    this.userInput = value;
  }
  getInputCodeValue(value: string) {
    this.userInputCode = value;
  }
  
  onConfirm(): boolean {
    if (this.confirmationCode && (this.userInputCode === this.confirmationCode)) {
      return true;
    }
    else if (!this.userInput || this.userInput === '') {
      this.errorResult = 'Digite um nome para o chat!';
      return false;
    }
    else {
      this.errorResult = 'Código de confirmação incorreto. Tente novamente.';
      return false;
    }
  }
}
