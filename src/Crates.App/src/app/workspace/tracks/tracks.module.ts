import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrackListComponent } from './track-list/track-list.component';
import { TrackDetailComponent } from './track-detail/track-detail.component';
import { TrackEditorComponent } from './track-editor/track-editor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '@shared';


@NgModule({
  declarations: [TrackListComponent, TrackDetailComponent, TrackEditorComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: "", component: TrackListComponent,
      }
    ])
  ]
})
export class TracksModule { }
