import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
  host: {
    'class': 'g-layout__container g-layout__nav-container'
  }
})
export class NavComponent {

  @Input() public items: NavItem[] = [];

  @Output() public itemClick: EventEmitter<any> = new EventEmitter();

}

export class NavItem {
  label: string;
  icon: string;
}
