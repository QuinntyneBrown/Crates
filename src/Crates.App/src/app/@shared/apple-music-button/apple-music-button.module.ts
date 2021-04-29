import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppleMusicButtonComponent } from './apple-music-button.component';



@NgModule({
  declarations: [AppleMusicButtonComponent],
  exports: [AppleMusicButtonComponent],
  imports: [
    CommonModule
  ]
})
export class AppleMusicButtonModule { }
