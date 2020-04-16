import { Injectable } from '@angular/core';
import { Overlay, OverlayRef } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { LoadingOverlayComponent } from '../loading-overlay/loading-overlay.component';
@Injectable({
  providedIn: 'root'
})
export class LoadingService {
    private overlayRef: OverlayRef;
    constructor(private overlay: Overlay) { }

    public show(message = ''): void {
        if (!this.overlayRef) {
            this.overlayRef = this.overlay.create();
        }

        const loadingComponentPortal = new ComponentPortal(LoadingOverlayComponent);
        const component = this.overlayRef.attach(loadingComponentPortal);
    }

    public hide(): void {
        if (!!this.overlayRef) {
            this.overlayRef.detach();
        }
    }
}