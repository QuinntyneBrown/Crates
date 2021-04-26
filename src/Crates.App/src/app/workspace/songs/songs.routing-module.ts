import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { SongListComponent } from "./song-list/song-list.component";

const routes: Routes = [
  { 
    path: "", component: SongListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SongsRoutingModule {}
