import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrackComponent } from './track.component';
import { RouterModule } from '@angular/router';
import { AppleMusicButtonModule } from '@shared/apple-music-button/apple-music-button.module';
import { SpotifyButtonModule } from '@shared/spotify-button/spotify-button.module';



@NgModule({
  declarations: [TrackComponent],
  imports: [
    CommonModule,
    AppleMusicButtonModule,
    SpotifyButtonModule,
    RouterModule.forChild([{
      path: "", component: TrackComponent
    }])
  ]
})
export class TrackModule { }
