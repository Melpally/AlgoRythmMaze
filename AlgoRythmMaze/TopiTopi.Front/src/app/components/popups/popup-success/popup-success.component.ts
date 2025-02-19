import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgIf } from "@angular/common";

@Component({
  selector: 'app-popup-success',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './popup-success.component.html',
  styleUrl: './popup-success.component.scss'
})
export class PopupSuccessComponent {

  @Output() showFlagChange: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() buttonClicked: EventEmitter<void> = new EventEmitter<void>();
  @Input({ required: true }) header: string = '';
  @Input() message: string = '';
  @Input({ required: true }) buttonLabel: string = '';
  show: boolean = false;

  close() {
    this.show = false;
    this.showFlagChange.emit(this.show);
  }

  initialMethod() {
    console.log("method undefined");
  }

  onClick() {
    this.close();
    this.buttonClicked.emit();
  }
}
