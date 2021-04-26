import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { 
    path: "", 
    loadChildren: () => import("src/app/public/landing/landing.module").then(x => x.LandingModule)   
  },
  { 
    path: "workspace", 
    loadChildren: () => import("src/app/workspace/workspace.module").then(x => x.WorkspaceModule)   
  }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
