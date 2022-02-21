import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { UserListComponent } from './user-list/user-list.component';

import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { UserFormComponent } from './user-form/user-form.component';
import { ApiClientService } from 'src/services/api-client.service';
import { AssetListComponent } from './asset-list/asset-list.component';

@NgModule({
  declarations: [
    AppComponent,
    MainMenuComponent,
    UserListComponent,
    UserFormComponent,
    AssetListComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ApiClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
