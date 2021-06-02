import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetListComponent } from './digital-asset-list/digital-asset-list.component';
import { DigitalAssetEditorComponent } from './digital-asset-editor/digital-asset-editor.component';
import { DigitalAssetDetailComponent } from './digital-asset-detail/digital-asset-detail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DigitalAssetUrlInputComponent } from './digital-asset-url-input/digital-asset-url-input.component';
import { DigitalAssetUploadModule } from './digital-asset-upload/digital-asset-upload.module';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '@shared';


@NgModule({
  declarations: [
    DigitalAssetListComponent,
     DigitalAssetEditorComponent,
     DigitalAssetDetailComponent,
     DigitalAssetUrlInputComponent
    ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild([
      {
        path: "", pathMatch: 'full', component: DigitalAssetListComponent,
      }
    ]),
    DigitalAssetUploadModule
  ]
})
export class DigitalAssetsModule { }
