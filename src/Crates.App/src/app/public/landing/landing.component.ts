import { Component, Inject, OnInit } from '@angular/core';
import { Playlist, PlaylistService } from '@api';
import { baseUrl } from '@core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss'],
  host: {
    'class':'g-typography'
  }
})
export class LandingComponent {

  public vm$: Observable<{ playlists: Playlist[]}> = this._playlistService.get()
  .pipe(
    map(playlists => {
      return {
        playlists
      };
    })
  );

  constructor(
    private readonly _playlistService: PlaylistService,
    @Inject(baseUrl) public baseUrl: string
  ) {

  }

}
