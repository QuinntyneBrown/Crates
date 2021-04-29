import { Component, ElementRef, forwardRef, OnInit } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { BehaviorSubject, fromEvent, Subject } from 'rxjs';
import { switchMap, takeUntil, tap } from 'rxjs/operators';
import { DigitalAsset } from '../digital-asset';
import { DigitalAssetService } from '../digital-asset.service';

@Component({
  selector: 'app-digital-asset-upload',
  templateUrl: './digital-asset-upload.component.html',
  styleUrls: ['./digital-asset-upload.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DigitalAssetUploadComponent),
      multi: true
    }
  ]
})
export class DigitalAssetUploadComponent implements ControlValueAccessor {

  private readonly _destroyed$: Subject<void> = new Subject();
  public digitalAsset$: Subject<DigitalAsset> = new  Subject();

  constructor(
    private readonly _digitalAssetService: DigitalAssetService,
    private readonly _elementRef: ElementRef
  ) {
    this.onDragOver = this.onDragOver.bind(this);
    this.onDrop = this.onDrop.bind(this);
  }

  digitalAssetId$: BehaviorSubject<string> = new BehaviorSubject(null);

  writeValue(obj: any): void { 
    if(obj) {
      this.digitalAssetId$.next(obj)      
    }

  }

  public registerOnChange(fn: any): void { 
    
    this.digitalAssetId$
    .pipe(
      tap(x => fn(x)),
      takeUntil(this._destroyed$)
    ).subscribe();
  }

  registerOnTouched(fn: any): void {

  }

  setDisabledState?(isDisabled: boolean): void {
    
  }


  public ngAfterViewInit(): void {
    fromEvent(this._elementRef.nativeElement,"dragover")
    .pipe(
      tap((x: DragEvent) => this.onDragOver(x)),
      takeUntil(this._destroyed$)
    ).subscribe();
    
    fromEvent(this._elementRef.nativeElement,"drop")
    .pipe(
      tap((x: DragEvent) => this.onDrop(x)),
      takeUntil(this._destroyed$)
    ).subscribe();
  }

  public ngOnDestroy(): void {
    this._destroyed$.next();
    this._destroyed$.complete();
  }

  public onDragOver(e: DragEvent): void {
    e.stopPropagation();
    e.preventDefault();
  }

  public async onDrop(e: DragEvent): Promise<any> {
    e.stopPropagation();
    e.preventDefault();

    if (e.dataTransfer && e.dataTransfer.files) {
      const packageFiles = function (fileList: FileList): FormData {
        const formData = new FormData();
        for (var i = 0; i < fileList.length; i++) {
          formData.append(fileList[i].name, fileList[i]);
        }
        return formData;
      }

      const data = packageFiles(e.dataTransfer.files);

      this._digitalAssetService.upload({ data })
        .pipe(
          switchMap((x) => this._digitalAssetService.getByIds({ digitalAssetIds: x.digitalAssetIds })),
          tap(x => this.digitalAssetId$.next(x[0].digitalAssetId)),
          takeUntil(this._destroyed$)
        )
        .subscribe();
    }
  }
}
