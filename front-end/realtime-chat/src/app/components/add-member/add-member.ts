import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-add-member',
  standalone: false,
  templateUrl: './add-member.html',
  styleUrl: './add-member.scss',
})
export class AddMember {

  showConfirmationModal: boolean = false;
  modalDangerMode: boolean = false;
  @Output() goBack = new EventEmitter<boolean>();

  confirm($event: boolean) {
    if($event)
      this.closeModal();
  }
  openModal() {
    this.showConfirmationModal = true;
    this.modalDangerMode = false;
  }
  openModalDangerMode() {
    this.showConfirmationModal = true;
    this.modalDangerMode = true;
  }
  closeModal() {
    this.showConfirmationModal = false;
  }

  emmitGoBack() {
    this.goBack.emit();
  }
}
