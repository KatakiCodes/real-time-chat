import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-button-danger',
  standalone: false,
  templateUrl: './button-danger.html',
  styleUrl: './button-danger.scss',
})
export class ButtonDanger {
  @Input({required: true}) text: string = '';
}
