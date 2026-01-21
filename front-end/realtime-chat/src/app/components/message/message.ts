import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-message',
  standalone: false,
  templateUrl: './message.html',
  styleUrl: './message.scss',
})
export class Message {
  @Input({alias: 'isCurrentUser'}) isMessageFromCurrentUser: boolean = false;
  @Input({required: true}) message: string = '';
}
