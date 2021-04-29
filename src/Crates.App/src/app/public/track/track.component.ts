import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { baseUrl } from '@core';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { Track } from 'src/app/workspace/tracks/track';
import { TrackService } from 'src/app/workspace/tracks/track.service';

@Component({
  selector: 'app-track',
  templateUrl: './track.component.html',
  styleUrls: ['./track.component.scss']
})
export class TrackComponent {

  public get baseServeUrl() { return `${this.baseUrl}api/digitalasset/serve/`; }

  public vm$: Observable<{ track: Track }> = this._activatedRoute.paramMap.pipe(
    map(paramMap => paramMap.get("trackId")),
    switchMap(trackId => this._trackService.getById({ trackId })),
    map(track => {
      return {
        track
      }
    })
  )

  constructor(
    @Inject(baseUrl) public baseUrl: string,
    private readonly _trackService: TrackService,
    private readonly _activatedRoute: ActivatedRoute
  ) { }


}
