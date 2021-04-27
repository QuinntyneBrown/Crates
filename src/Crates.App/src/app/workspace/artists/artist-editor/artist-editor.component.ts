import { Component, ElementRef, forwardRef, Input, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, ControlValueAccessor, FormArray, FormControl, FormGroup, NG_VALIDATORS, NG_VALUE_ACCESSOR, ValidationErrors, Validator, Validators } from '@angular/forms';
import { fromEvent, Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';;
import { Artist } from '../artist';

@Component({
  selector: 'app-artist-editor',
  templateUrl: './artist-editor.component.html',
  styleUrls: ['./artist-editor.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ArtistEditorComponent),
      multi: true
    },
    {
      provide: NG_VALIDATORS,
      useExisting: forwardRef(() => ArtistEditorComponent),
      multi: true
    }       
  ]
})
export class ArtistEditorComponent implements ControlValueAccessor,  Validator  {
  private readonly _destroyed$: Subject<void> = new Subject();

  public form = new FormGroup({
    artistId: new FormControl(),
    name: new FormControl(null, [Validators.required]),
  });

  constructor(
    private readonly _elementRef: ElementRef
  ) { }

  validate(control: AbstractControl): ValidationErrors {
    return this.form.valid
      ? null
      : Object.keys(this.form.controls).reduce(
          (accumulatedErrors, formControlName) => {
            const errors = { ...accumulatedErrors };

            const controlErrors = this.form.controls[formControlName].errors;

            if (controlErrors) {
              errors[formControlName] = controlErrors;
            }

            return errors;
          },
          {}
        );
  }
  
  writeValue(artist: Artist): void {   
    this.form.patchValue(artist || {}, { emitEvent: false });
  }

  registerOnChange(fn: any): void {
    this.form.valueChanges.subscribe(fn);
  }

  registerOnTouched(fn: any): void {
    this._elementRef.nativeElement
      .querySelectorAll("*")
      .forEach((element: HTMLElement) => {
        fromEvent(element, "focus")
          .pipe(
            takeUntil(this._destroyed$),
            tap(x => fn())
          )
          .subscribe();
      });
  }

  setDisabledState?(isDisabled: boolean): void {
    isDisabled ? this.form.disable() : this.form.enable();
  }
}
