import { Injectable } from '@angular/core';
import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { OverlayComponent } from '../layout/overlay/overlay.component';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  private overlayRef: OverlayRef | null;
  constructor(private overlay: Overlay) {
    this.overlayRef = null;
  }

  public show(message: string): void {
    if (this.overlayRef === null) {
      this.overlayRef= this.overlay.create();
    }

    const loadingComponentPortal = new ComponentPortal(OverlayComponent);
    const component = this.overlayRef.attach(loadingComponentPortal);
  }

  public hide(): void {
    if (!!this.overlayRef) {
      this.overlayRef.detach();
    }
  }
}
