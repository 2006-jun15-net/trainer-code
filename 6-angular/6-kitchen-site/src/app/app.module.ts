import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FridgeComponent } from './fridge/fridge.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  // the components, directives, and pipes that belong to this module
  declarations: [
    AppComponent,
    FridgeComponent
  ],
  // all the components, directives, and pipes that other modules could use
  // if they imported this one. (if you leave something out here, it's like "internal" in C#)
  exports: [],
  // all the modules that contain things something in this module wants to use
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  // any services to provide at module-scope
  providers: [],
  // for the root module: identify the root component to bootstrap
  // (unrelated to bootstrap css/js)
  bootstrap: [AppComponent]
})
export class AppModule { }
