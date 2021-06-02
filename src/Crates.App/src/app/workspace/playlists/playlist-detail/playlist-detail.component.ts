import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Playlist,PlaylistService } from '@api';

@Component({
  selector: 'app-playlist-detail',
  templateUrl: './playlist-detail.component.html',
  styleUrls: ['./playlist-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class PlaylistDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public playlist$: BehaviorSubject<Playlist> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.playlist$
  ]).pipe(
    map(([playlist]) => {
      return {
        form: new FormGroup({
          playlist: new FormControl(playlist, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _playlistService: PlaylistService) {
  }

  public save(vm: { form: FormGroup}) {
    const playlist = vm.form.value.playlist;
    let obs$: Observable<{ playlist: Playlist }>;
    if(playlist.playlistId) {
      obs$ = this._playlistService.update({ playlist })
    }
    else {
      obs$ = this._playlistService.create({ playlist })
    }

    obs$.pipe(
      takeUntil(this._destroyed),
      tap(x => {
        this.saved.next(x.playlist);
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
