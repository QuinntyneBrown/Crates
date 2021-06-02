import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EntityActionsComponent } from './entity-actions.component';
import { MaterialModule } from '@shared/material.module';

@NgModule({
  declarations: [EntityActionsComponent],
  exports: [EntityActionsComponent],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class EntityActionsModule { }
