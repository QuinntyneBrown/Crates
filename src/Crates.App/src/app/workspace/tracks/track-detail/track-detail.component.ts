import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Track } from '../track';
import { TrackService } from '../track.service';

@Component({
  selector: 'app-track-detail',
  templateUrl: './track-detail.component.html',
  styleUrls: ['./track-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class TrackDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public track$: BehaviorSubject<Track> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.track$
  ]).pipe(
    map(([track]) => {
      return {
        form: new FormGroup({
          track: new FormControl(track, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _trackService: TrackService) {     
  }

  public save(vm: { form: FormGroup}) {
    const track = vm.form.value.track;
    let obs$: Observable<{ track: Track }>;
    if(track.trackId) {
      obs$ = this._trackService.update({ track })
    }   
    else {
      obs$ = this._trackService.create({ track })
    } 

    obs$.pipe(
      takeUntil(this._destroyed),      
      tap(x => {
        this.saved.next(x.track);
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
