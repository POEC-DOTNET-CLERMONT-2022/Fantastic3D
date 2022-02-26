import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserListComponent } from './user-list/user-list.component';
import { UserFormComponent } from './user-form/user-form.component';
import { AssetListComponent } from './asset-list/asset-list.component';
import { MainMenuComponent } from './main-menu/main-menu.component';

const routes: Routes = [
  { path: MainMenuComponent.pathUsers, component: UserListComponent },
  { path: MainMenuComponent.pathUsers + '/:userId', component: UserFormComponent },
  { path: MainMenuComponent.pathUserNew, component: UserFormComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
