import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SongListComponent } from './song-list/song-list.component';
import { SongDetailComponent } from './song-detail/song-detail.component';
import { SongEditorComponent } from './song-editor/song-editor.component';



@NgModule({
  declarations: [SongListComponent, SongDetailComponent, SongEditorComponent],
  imports: [
    CommonModule
  ]
})
export class SongsModule { }
