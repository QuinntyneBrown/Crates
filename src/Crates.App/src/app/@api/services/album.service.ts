import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Album } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class AlbumService implements IPagableService<Album> {

  uniqueIdentifierName: string = "albumId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Album>> {
    return this._client.get<EntityPage<Album>>(`${this._baseUrl}api/album/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Album[]> {
    return this._client.get<{ albums: Album[] }>(`${this._baseUrl}api/album`)
      .pipe(
        map(x => x.albums)
      );
  }

  public getById(options: { albumId: string }): Observable<Album> {
    return this._client.get<{ album: Album }>(`${this._baseUrl}api/album/${options.albumId}`)
      .pipe(
        map(x => x.album)
      );
  }

  public remove(options: { album: Album }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/album/${options.album.albumId}`);
  }

  public create(options: { album: Album }): Observable<{ album: Album }> {
    return this._client.post<{ album: Album }>(`${this._baseUrl}api/album`, { album: options.album });
  }
  
  public update(options: { album: Album }): Observable<{ album: Album }> {
    return this._client.put<{ album: Album }>(`${this._baseUrl}api/album`, { album: options.album });
  }
}
