import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArtistListComponent } from './artist-list/artist-list.component';
import { ArtistDetailComponent } from './artist-detail/artist-detail.component';
import { ArtistEditorComponent } from './artist-editor/artist-editor.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '@shared';



@NgModule({
  declarations: [ArtistListComponent, ArtistDetailComponent, ArtistEditorComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: "", component: ArtistListComponent,
      }
    ])
  ]
})
export class ArtistsModule { }
