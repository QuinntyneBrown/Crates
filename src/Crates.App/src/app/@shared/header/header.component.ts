import { Component, Output, EventEmitter, Input } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  host: {
    'class':'g-layout__container'
  }
})
export class HeaderComponent {
  @Output() searchClick: EventEmitter<any> = new EventEmitter();

  @Output() menuClick: EventEmitter<any> = new EventEmitter();

  @Output() profileClick: EventEmitter<any> = new EventEmitter();

  @Output() shoppingCartClick: EventEmitter<any> = new EventEmitter();

  @Output() logoClick: EventEmitter<any> = new EventEmitter();

  @Input() logoUrl: string;
}
