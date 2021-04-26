import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { WorkspaceComponent } from './workspace/workspace.component';



@NgModule({
  declarations: [
    WorkspaceComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([{
      path: "", component: WorkspaceComponent
    }])
  ]
})
export class WorkspaceModule { }
