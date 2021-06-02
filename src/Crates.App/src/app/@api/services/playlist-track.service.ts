import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { PlaylistTrack } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class PlaylistTrackService implements IPagableService<PlaylistTrack> {

  uniqueIdentifierName: string = "playlistTrackId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<PlaylistTrack>> {
    return this._client.get<EntityPage<PlaylistTrack>>(`${this._baseUrl}api/playlistTrack/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<PlaylistTrack[]> {
    return this._client.get<{ playlistTracks: PlaylistTrack[] }>(`${this._baseUrl}api/playlistTrack`)
      .pipe(
        map(x => x.playlistTracks)
      );
  }

  public getById(options: { playlistTrackId: string }): Observable<PlaylistTrack> {
    return this._client.get<{ playlistTrack: PlaylistTrack }>(`${this._baseUrl}api/playlistTrack/${options.playlistTrackId}`)
      .pipe(
        map(x => x.playlistTrack)
      );
  }

  public remove(options: { playlistTrack: PlaylistTrack }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/playlistTrack/${options.playlistTrack.playlistTrackId}`);
  }

  public create(options: { playlistTrack: PlaylistTrack }): Observable<{ playlistTrack: PlaylistTrack }> {
    return this._client.post<{ playlistTrack: PlaylistTrack }>(`${this._baseUrl}api/playlistTrack`, { playlistTrack: options.playlistTrack });
  }
  
  public update(options: { playlistTrack: PlaylistTrack }): Observable<{ playlistTrack: PlaylistTrack }> {
    return this._client.put<{ playlistTrack: PlaylistTrack }>(`${this._baseUrl}api/playlistTrack`, { playlistTrack: options.playlistTrack });
  }
}
