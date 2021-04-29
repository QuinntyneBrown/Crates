import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpotifyButtonComponent } from './spotify-button.component';



@NgModule({
  declarations: [SpotifyButtonComponent],
  exports:[
    SpotifyButtonComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SpotifyButtonModule { }
