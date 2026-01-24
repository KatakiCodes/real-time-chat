import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-room',
  standalone: false,
  templateUrl: './room.html',
  styleUrl: './room.scss',
})
export class Room {
  showOptions: boolean = false;
  showAddMember: boolean = false;

  toggleOptions(event:MouseEvent) {
    event.stopPropagation();
    this.showOptions = !this.showOptions;
  }
  closeOptions() {
    this.showOptions = false;
  }
  @HostListener('click',['$event'])
  onDocumentClick(event:MouseEvent){
    this.closeOptions();
  }
  toggleShowAddMember(){
    this.showAddMember = !this.showAddMember;
  }
  closeAddMember(){
    this.showAddMember = false;
  }
}