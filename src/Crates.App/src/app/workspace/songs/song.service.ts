import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Song } from './song';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class SongService implements IPagableService<Song> {

  uniqueIdentifierName: string = "songId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Song>> {
    return this._client.get<EntityPage<Song>>(`${this._baseUrl}api/song/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Song[]> {
    return this._client.get<{ songs: Song[] }>(`${this._baseUrl}api/song`)
      .pipe(
        map(x => x.songs)
      );
  }

  public getById(options: { songId: string }): Observable<Song> {
    return this._client.get<{ song: Song }>(`${this._baseUrl}api/song/${options.songId}`)
      .pipe(
        map(x => x.song)
      );
  }

  public remove(options: { song: Song }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/song/${options.song.songId}`);
  }

  public create(options: { song: Song }): Observable<{ song: Song }> {
    return this._client.post<{ song: Song }>(`${this._baseUrl}api/song`, { song: options.song });
  }
  
  public update(options: { song: Song }): Observable<{ song: Song }> {
    return this._client.put<{ song: Song }>(`${this._baseUrl}api/song`, { song: options.song });
  }
}
