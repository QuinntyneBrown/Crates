import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '@core';

const routes: Routes = [
  {
    path: "login",
    loadChildren: () => import("src/app/public/login/login.module").then(x => x.LoginModule)
  },
  {
    path: "",
    loadChildren: () => import("src/app/public/landing/landing.module").then(x => x.LandingModule)
  },
  {
    path: "playlist/:playlistId",
    loadChildren: () => import("src/app/public/playlist/playlist.module").then(x => x.PlaylistModule)
  },
  {
    path: "workspace",
    loadChildren: () => import("src/app/workspace/workspace.module").then(x => x.WorkspaceModule),
    canActivate:[AuthGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    scrollPositionRestoration: 'top',
    paramsInheritanceStrategy: 'always'
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
