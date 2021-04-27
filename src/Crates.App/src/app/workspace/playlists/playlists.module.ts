import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaylistListComponent } from './playlist-list/playlist-list.component';
import { PlaylistDetailComponent } from './playlist-detail/playlist-detail.component';
import { PlaylistEditorComponent } from './playlist-editor/playlist-editor.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DigitalAssetUploadModule } from '../digital-assets/digital-asset-upload/digital-asset-upload.module';



@NgModule({
  declarations: [PlaylistListComponent, PlaylistDetailComponent, PlaylistEditorComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    DigitalAssetUploadModule,
    FormsModule,
    RouterModule.forChild( [
      { 
        path: "", component: PlaylistListComponent,
      }
    ])
  ]
})
export class PlaylistsModule { }
