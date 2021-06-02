import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetUploadComponent } from './digital-asset-upload.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@shared';

@NgModule({
  declarations: [DigitalAssetUploadComponent],
  exports:[DigitalAssetUploadComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule
  ]
})
export class DigitalAssetUploadModule { }
