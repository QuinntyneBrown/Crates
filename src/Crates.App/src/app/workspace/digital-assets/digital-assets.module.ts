import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetListComponent } from './digital-asset-list/digital-asset-list.component';
import { DigitalAssetDetailComponent } from './digital-asset-detail/digital-asset-detail.component';
import { DigitalAssetEditorComponent } from './digital-asset-editor/digital-asset-editor.component';



@NgModule({
  declarations: [DigitalAssetListComponent, DigitalAssetDetailComponent, DigitalAssetEditorComponent],
  imports: [
    CommonModule
  ]
})
export class DigitalAssetsModule { }
