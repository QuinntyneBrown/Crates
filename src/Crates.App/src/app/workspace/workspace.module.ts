import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { WorkspaceComponent } from './workspace/workspace.component';
import { WorkspaceHeaderModule } from '@shared/workspace-header/workspace-header.module';



@NgModule({
  declarations: [
    WorkspaceComponent
  ],
  imports: [
    CommonModule,
    WorkspaceHeaderModule,
    RouterModule.forChild([{
      path: "", component: WorkspaceComponent,
      children: [
        {
          path: "",
          loadChildren: () => import("src/app/workspace/playlists/playlists.module").then(x => x.PlaylistsModule)
        },
        {
          path: "tracks",
          loadChildren: () => import("src/app/workspace/tracks/tracks.module").then(x => x.TracksModule)
        },
        {
          path: "artists",
          loadChildren: () => import("src/app/workspace/artists/artists.module").then(x => x.ArtistsModule)
        },
        {
          path: "digital-assets",
          loadChildren: () => import("src/app/workspace/digital-assets/digital-assets.module").then(x => x.DigitalAssetsModule)
        }
      ]
    }])
  ]
})
export class WorkspaceModule { }
