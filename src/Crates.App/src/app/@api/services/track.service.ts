import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Track } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class TrackService implements IPagableService<Track> {

  uniqueIdentifierName: string = "trackId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Track>> {
    return this._client.get<EntityPage<Track>>(`${this._baseUrl}api/track/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Track[]> {
    return this._client.get<{ tracks: Track[] }>(`${this._baseUrl}api/track`)
      .pipe(
        map(x => x.tracks)
      );
  }

  public getById(options: { trackId: string }): Observable<Track> {
    return this._client.get<{ track: Track }>(`${this._baseUrl}api/track/${options.trackId}`)
      .pipe(
        map(x => x.track)
      );
  }

  public remove(options: { track: Track }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/track/${options.track.trackId}`);
  }

  public create(options: { track: Track }): Observable<{ track: Track }> {
    return this._client.post<{ track: Track }>(`${this._baseUrl}api/track`, { track: options.track });
  }
  
  public update(options: { track: Track }): Observable<{ track: Track }> {
    return this._client.put<{ track: Track }>(`${this._baseUrl}api/track`, { track: options.track });
  }
}
