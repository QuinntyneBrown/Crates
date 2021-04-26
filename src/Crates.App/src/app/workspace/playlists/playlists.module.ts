import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaylistListComponent } from './playlist-list/playlist-list.component';
import { PlaylistDetailComponent } from './playlist-detail/playlist-detail.component';
import { PlaylistEditorComponent } from './playlist-editor/playlist-editor.component';



@NgModule({
  declarations: [PlaylistListComponent, PlaylistDetailComponent, PlaylistEditorComponent],
  imports: [
    CommonModule
  ]
})
export class PlaylistsModule { }
