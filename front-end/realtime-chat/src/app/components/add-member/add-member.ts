import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-add-member',
  standalone: false,
  templateUrl: './add-member.html',
  styleUrl: './add-member.scss',
})
export class AddMember {
  @Output() goBack = new EventEmitter<boolean>();

  emmitGoBack(){
    this.goBack.emit();
  }
}
