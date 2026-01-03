import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-button-primary',
  standalone: false,
  templateUrl: './button-primary.html',
  styleUrl: './button-primary.scss',
})
export class ButtonPrimary {
  @Input() text: string = '';
}
