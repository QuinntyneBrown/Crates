import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { baseUrl } from '@core';
import { Observable } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { Playlist } from 'src/app/workspace/playlists/playlist';
import { PlaylistService } from 'src/app/workspace/playlists/playlist.service';

@Component({
  selector: 'app-playlist',
  templateUrl: './playlist.component.html',
  styleUrls: ['./playlist.component.scss']
})
export class PlaylistComponent {


  public vm$: Observable<{ playlist: Playlist }> = this._activatedRoute.paramMap.pipe(
    map(x => x.get("playlistId")),
    switchMap(playlistId => this._playlistService.getById({ playlistId })),
    map(playlist => {
      return {
        playlist
      }
    })
  )

  constructor(
    private readonly _playlistService: PlaylistService,
    private readonly _activatedRoute: ActivatedRoute,
    @Inject(baseUrl) public baseUrl: string
  ) { }

}
