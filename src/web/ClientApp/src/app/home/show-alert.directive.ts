import { Directive, ElementRef, Input } from '@angular/core';

@Directive({
  selector: '[showAlert]'
})
export class ShowAlertDirective {

  @Input() showAlert: boolean;

  constructor(private el: ElementRef) {
    if (this.showAlert) {
      el.nativeElement.class = `alert alert-danger`;
    }
  }
}
