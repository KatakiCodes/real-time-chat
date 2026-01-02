import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-button-primary-outlined',
  standalone: false,
  templateUrl: './button-primary-outlined.html',
  styleUrl: './button-primary-outlined.scss',
})
export class ButtonPrimaryOutlined {
  @Input() text: string = '';
}
