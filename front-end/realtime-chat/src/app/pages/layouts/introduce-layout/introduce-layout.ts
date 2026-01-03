import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-introduce-layout',
  standalone: false,
  templateUrl: './introduce-layout.html',
  styleUrl: './introduce-layout.scss',
})
export class IntroduceLayout {
  @Input() heightIlustration: string = '-full';
}
