import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Playlist } from 'src/app/workspace/playlists/playlist';
import { PlaylistService } from 'src/app/workspace/playlists/playlist.service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss']
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
    private readonly _playlistService: PlaylistService
  ) { }

}
