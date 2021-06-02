import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Genre } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class GenreService implements IPagableService<Genre> {

  uniqueIdentifierName: string = "genreId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Genre>> {
    return this._client.get<EntityPage<Genre>>(`${this._baseUrl}api/genre/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Genre[]> {
    return this._client.get<{ genres: Genre[] }>(`${this._baseUrl}api/genre`)
      .pipe(
        map(x => x.genres)
      );
  }

  public getById(options: { genreId: string }): Observable<Genre> {
    return this._client.get<{ genre: Genre }>(`${this._baseUrl}api/genre/${options.genreId}`)
      .pipe(
        map(x => x.genre)
      );
  }

  public remove(options: { genre: Genre }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/genre/${options.genre.genreId}`);
  }

  public create(options: { genre: Genre }): Observable<{ genre: Genre }> {
    return this._client.post<{ genre: Genre }>(`${this._baseUrl}api/genre`, { genre: options.genre });
  }
  
  public update(options: { genre: Genre }): Observable<{ genre: Genre }> {
    return this._client.put<{ genre: Genre }>(`${this._baseUrl}api/genre`, { genre: options.genre });
  }
}
