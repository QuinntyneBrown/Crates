import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '@core';
import { LoginComponent } from './public/login/login/login.component';

const routes: Routes = [
  { path: "login", component: LoginComponent },
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
