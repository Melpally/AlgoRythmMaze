import {Component, EventEmitter, Input, Output} from '@angular/core';
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-popup-error',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './popup-error.component.html',
  styleUrl: './popup-error.component.scss'
})
export class PopupErrorComponent {

  @Input({required: true}) header: string = '';
  @Input() message: string = '';
  show: boolean = false;
  @Output() showFlagChange: EventEmitter<boolean> = new EventEmitter<boolean>();


  onClick() {
    this.close();
  }

  close(){
    this.show = false;
    this.showFlagChange.emit(this.show);
  }
}
