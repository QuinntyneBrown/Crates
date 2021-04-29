import { Component, ElementRef, Input, forwardRef } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';
import { switchMap } from 'rxjs/operators';
import { DigitalAssetService } from '../digital-asset.service';

@Component({
  selector: 'app-digital-asset-url-input',
  templateUrl: './digital-asset-url-input.component.html',
  styleUrls: ['./digital-asset-url-input.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DigitalAssetUrlInputComponent),
      multi: true
    }
  ]
})
export class DigitalAssetUrlInputComponent implements ControlValueAccessor {

  @Input()
  public placeholder: string;

  constructor(
    private elementRef: ElementRef,
    private digitalAssetsService: DigitalAssetService) {
    this.onDragOver = this.onDragOver.bind(this);
    this.onDrop = this.onDrop.bind(this);
  }

  public get value(): string { return this.inputElement.value; }

  public writeValue(value: any): void { this.inputElement.value = value; }

  public registerOnChange(fn: any): void { this.onChangeCallback = fn; }

  public registerOnTouched(fn: any): void { this.onTouchedCallback = fn; }

  public setDisabledState?(isDisabled: boolean): void { this.inputElement.disabled = isDisabled; }

  public onTouchedCallback: () => void = () => { };

  public onChangeCallback: (_: any) => void = () => { };

  public ngAfterViewInit(): void {
    this.elementRef.nativeElement.addEventListener("dragover", this.onDragOver);
    this.elementRef.nativeElement.addEventListener("drop", this.onDrop, false);
  }

  public ngOnDestroy(): void {
    this.elementRef.nativeElement.removeEventListener("dragover", this.onDragOver);
    this.elementRef.nativeElement.removeEventListener("drop", this.onDrop, false);
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

      this.digitalAssetsService.upload({ data })
        .pipe(
          switchMap((x) => this.digitalAssetsService.getByIds({ digitalAssetIds: x.digitalAssetIds }))
        )
        .subscribe(x => {
        this.inputElement.value = x[0].digitalAssetId;
        this.onChangeCallback(this.inputElement.value);
      });
    }
  }

  public get inputElement(): HTMLInputElement { return this.elementRef.nativeElement.querySelector('input'); }
}