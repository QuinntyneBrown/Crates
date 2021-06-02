import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Artist, ArtistService } from '@api';

@Component({
  selector: 'app-artist-detail',
  templateUrl: './artist-detail.component.html',
  styleUrls: ['./artist-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class ArtistDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public artist$: BehaviorSubject<Artist> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.artist$
  ]).pipe(
    map(([artist]) => {
      return {
        form: new FormGroup({
          artist: new FormControl(artist, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _artistService: ArtistService) {
  }

  public save(vm: { form: FormGroup}) {
    const artist = vm.form.value.artist;
    let obs$: Observable<{ artist: Artist }>;
    if(artist.artistId) {
      obs$ = this._artistService.update({ artist })
    }
    else {
      obs$ = this._artistService.create({ artist })
    }

    obs$.pipe(
      takeUntil(this._destroyed),
      tap(x => {
        this.saved.next(x.artist);
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
