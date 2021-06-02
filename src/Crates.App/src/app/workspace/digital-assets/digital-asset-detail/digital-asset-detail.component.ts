
import { Component, EventEmitter, OnDestroy, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { DigitalAsset, DigitalAssetService } from '@api';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-digital-asset-detail',
  templateUrl: './digital-asset-detail.component.html',
  styleUrls: ['./digital-asset-detail.component.scss']
})
export class DigitalAssetDetailComponent implements OnInit, OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();

  public digitalAsset$: BehaviorSubject<DigitalAsset> = new BehaviorSubject(null as any);

  public form: FormGroup = new FormGroup({
    digitalAsset: new FormControl()
  });

  @Output() public saved = new EventEmitter();

  ngOnInit() {

    this.form.valueChanges
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => {
        if(x.digtalAsset) {
          this._dialogRef.close();
        }
      })
    ).subscribe();
  }

  public vm$ = this.digitalAsset$.pipe(
    map(digitalAsset => {

      if(digitalAsset) {
        this.form.reset({
          digitalAsset
        }, { emitEvent: false })
      }
      return {

      }
    })
  );

  constructor(
    private readonly _dialogRef: MatDialogRef<DigitalAssetDetailComponent>,
    private readonly _digitalAssetService: DigitalAssetService) { }

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
      takeUntil(this._destroyed$),
      tap(x => {
        this.saved.next(x.digitalAsset);
        this._dialogRef.close();
      })
    ).subscribe();
  }

  public cancel() {
    this._dialogRef.close();
  }

  ngOnDestroy() {
    this._destroyed$.complete();
    this._destroyed$.next();
  }
}
