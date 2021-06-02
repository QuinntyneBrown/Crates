import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, of, Subject } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { DigitalAsset } from '../digital-asset';
import { DigitalAssetService } from '../digital-asset.service';

@Component({
  selector: 'app-digital-asset-detail',
  templateUrl: './digital-asset-detail.component.html',
  styleUrls: ['./digital-asset-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class DigitalAssetDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public digitalAsset$: BehaviorSubject<DigitalAsset> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.digitalAsset$
  ]).pipe(
    switchMap(([digitalAsset]) => {
      const form = new FormGroup({
        digitalAsset: new FormControl(digitalAsset, [])
      });

      if(!this.digitalAsset$?.value?.digitalAssetId) {
        return form.valueChanges
        .pipe(
          tap(x => {
            this.saved.next(x.digitalAsset);
            this._overlayRef.dispose();
          })
        )
      }

      return of({
        form
      })
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _digitalAssetService: DigitalAssetService) { 

  }

  public save(vm: { form: FormGroup}) {
    const digitalAsset = vm.form.value.digitalAsset;
    let obs$: Observable<{ digitalAsset: DigitalAsset }>;
    if(digitalAsset.digitalAssetId) {
      obs$ = this._digitalAssetService.update({ digitalAsset })
    }   
    else {
      obs$ = this._digitalAssetService.create({ digitalAsset })
    } 

    obs$.pipe(
      takeUntil(this._destroyed),      
      tap(x => {
        this.saved.next(x.digitalAsset);
        this._overlayRef.dispose();
      })
    ).subscribe();
  }

  public cancel() {
    this._overlayRef.dispose();
  }

  ngOnDestroy() {
    this._destroyed.complete();
    this._destroyed.next();
  }
}
