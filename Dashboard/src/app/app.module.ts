import { ServermappingService } from './servermapping.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { ServermappingComponent } from './servermapping/servermapping.component';


@NgModule({
  declarations: [
    AppComponent,
    ServermappingComponent
  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [ServermappingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
