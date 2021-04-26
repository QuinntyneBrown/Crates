import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { DigitalAssetListComponent } from "./digital-asset-list/digital-asset-list.component";

const routes: Routes = [
  { 
    path: "", component: DigitalAssetListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DigitalAssetsRoutingModule {}
