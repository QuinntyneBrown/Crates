import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { baseUrl } from '@core';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { TrackService, Track } from '@api';

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
    map(track => ({ track }))
  )

  constructor(
    @Inject(baseUrl) public baseUrl: string,
    private readonly _trackService: TrackService,
    private readonly _activatedRoute: ActivatedRoute
  ) { }


}
