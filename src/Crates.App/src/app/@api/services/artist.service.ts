import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Artist } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ArtistService implements IPagableService<Artist> {

  uniqueIdentifierName: string = "artistId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Artist>> {
    return this._client.get<EntityPage<Artist>>(`${this._baseUrl}api/artist/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Artist[]> {
    return this._client.get<{ artists: Artist[] }>(`${this._baseUrl}api/artist`)
      .pipe(
        map(x => x.artists)
      );
  }

  public getById(options: { artistId: string }): Observable<Artist> {
    return this._client.get<{ artist: Artist }>(`${this._baseUrl}api/artist/${options.artistId}`)
      .pipe(
        map(x => x.artist)
      );
  }

  public remove(options: { artist: Artist }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/artist/${options.artist.artistId}`);
  }

  public create(options: { artist: Artist }): Observable<{ artist: Artist }> {
    return this._client.post<{ artist: Artist }>(`${this._baseUrl}api/artist`, { artist: options.artist });
  }
  
  public update(options: { artist: Artist }): Observable<{ artist: Artist }> {
    return this._client.put<{ artist: Artist }>(`${this._baseUrl}api/artist`, { artist: options.artist });
  }
}
