import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Song } from '../song';
import { SongService } from '../song.service';

@Component({
  selector: 'app-song-detail',
  templateUrl: './song-detail.component.html',
  styleUrls: ['./song-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class SongDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public song$: BehaviorSubject<Song> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.song$
  ]).pipe(
    map(([song]) => {
      return {
        form: new FormGroup({
          song: new FormControl(song, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _songService: SongService) {     
  }

  public save(vm: { form: FormGroup}) {
    const song = vm.form.value.song;
    let obs$: Observable<{ song: Song }>;
    if(song.songId) {
      obs$ = this._songService.update({ song })
    }   
    else {
      obs$ = this._songService.create({ song })
    } 

    obs$.pipe(
      takeUntil(this._destroyed),      
      tap(x => {
        this.saved.next(x.song);
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
