import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HtmlEditorComponent } from './html-editor/html-editor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSummernoteModule } from 'ngx-summernote';



@NgModule({
  declarations: [HtmlEditorComponent],
  exports: [
    HtmlEditorComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    NgxSummernoteModule
  ]
})
export class HtmlEditorModule { }
