import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { DialogService } from '@shared/dialog.service';
import { BehaviorSubject, combineLatest, Observable, of, Subject } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { DigitalAsset } from '../digital-asset';
import { DigitalAssetDetailComponent } from '../digital-asset-detail/digital-asset-detail.component';
import { DigitalAssetService } from '../digital-asset.service';
import { MatPaginator } from '@angular/material/paginator';
import { EntityDataSource } from '@shared/entity-data-source';

@Component({
  selector: 'app-digital-asset-list',
  templateUrl: './digital-asset-list.component.html',
  styleUrls: ['./digital-asset-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  host: {
    'class':'g-layout__container g-layout__list-container'
  }
})
export class DigitalAssetListComponent implements OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  private readonly index$: BehaviorSubject<number> = new BehaviorSubject(0);
  private readonly pageSize$: BehaviorSubject<number> = new BehaviorSubject(5);
  private readonly _dataSource: EntityDataSource<DigitalAsset> = new EntityDataSource(this._digitalAssetService);

  public readonly vm$: Observable<{
    dataSource: EntityDataSource<DigitalAsset>,
    columnsToDisplay: string[],
    length$: Observable<number>,
    pageNumber: number,
    pageSize: number
  }> = combineLatest([this.index$, this.pageSize$ ])
  .pipe(
    switchMap(([index,pageSize]) => combineLatest([
      of([
        'name',
        'edit'
      ]),
      of(index),
      of(pageSize)  
    ])
    .pipe(
      map(([columnsToDisplay, pageNumber, pageSize]) => { 
        this._dataSource.getPage({ index, pageSize });
        return {
          dataSource: this._dataSource,
          columnsToDisplay,
          length$: this._dataSource.length$,
          pageSize,
          pageNumber
        }
      })
    ))
  );
  
  constructor(
    private readonly _digitalAssetService: DigitalAssetService,
    private readonly _dialogService: DialogService,
  ) { }

  public edit(digitalAsset: DigitalAsset) {
    const component = this._dialogService.open<DigitalAssetDetailComponent>(DigitalAssetDetailComponent);
    component.digitalAsset$.next(digitalAsset);    
    component.saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this._dataSource.update(x))
    ).subscribe();
  }

  public create() {
    this._dialogService.open<DigitalAssetDetailComponent>(DigitalAssetDetailComponent)
    .saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }

  public delete(digitalAsset: DigitalAsset) {    
    this._digitalAssetService.remove({ digitalAsset }).pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }
  
  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
