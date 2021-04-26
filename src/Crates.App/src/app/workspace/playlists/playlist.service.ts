import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Playlist } from './playlist';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class PlaylistService implements IPagableService<Playlist> {

  uniqueIdentifierName: string = "playlistId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Playlist>> {
    return this._client.get<EntityPage<Playlist>>(`${this._baseUrl}api/playlist/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Playlist[]> {
    return this._client.get<{ playlists: Playlist[] }>(`${this._baseUrl}api/playlist`)
      .pipe(
        map(x => x.playlists)
      );
  }

  public getById(options: { playlistId: string }): Observable<Playlist> {
    return this._client.get<{ playlist: Playlist }>(`${this._baseUrl}api/playlist/${options.playlistId}`)
      .pipe(
        map(x => x.playlist)
      );
  }

  public remove(options: { playlist: Playlist }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/playlist/${options.playlist.playlistId}`);
  }

  public create(options: { playlist: Playlist }): Observable<{ playlist: Playlist }> {
    return this._client.post<{ playlist: Playlist }>(`${this._baseUrl}api/playlist`, { playlist: options.playlist });
  }
  
  public update(options: { playlist: Playlist }): Observable<{ playlist: Playlist }> {
    return this._client.put<{ playlist: Playlist }>(`${this._baseUrl}api/playlist`, { playlist: options.playlist });
  }
}
