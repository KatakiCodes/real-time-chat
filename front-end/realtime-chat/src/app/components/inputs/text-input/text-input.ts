import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-text-input',
  standalone: false,
  templateUrl: './text-input.html',
  styleUrl: './text-input.scss',
})
export class TextInput {
  @Input() type: string = 'text';
  @Input() placeholder: string = '';
}
