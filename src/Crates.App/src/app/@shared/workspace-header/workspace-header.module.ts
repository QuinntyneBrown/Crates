import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspaceHeaderComponent } from './workspace-header.component';



@NgModule({
  declarations: [WorkspaceHeaderComponent],
  exports: [WorkspaceHeaderComponent],
  imports: [
    CommonModule
  ]
})
export class WorkspaceHeaderModule { }
