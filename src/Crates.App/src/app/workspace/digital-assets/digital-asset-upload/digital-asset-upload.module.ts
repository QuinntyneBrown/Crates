import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetUploadComponent } from './digital-asset-upload.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '@shared/shared.module';

@NgModule({
  declarations: [DigitalAssetUploadComponent],
  exports:[DigitalAssetUploadComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule
  ]
})
export class DigitalAssetUploadModule { }
