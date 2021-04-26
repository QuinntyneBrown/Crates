import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { PlaylistListComponent } from "./playlist-list/playlist-list.component";

const routes: Routes = [
  { 
    path: "", component: PlaylistListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PlaylistsRoutingModule {}
