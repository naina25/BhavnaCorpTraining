import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchComponentComponent } from './search-component/search-component.component';
import { OptionsCardsComponent } from './options-cards/options-cards.component';
import { CollectionsComponent } from './collections/collections.component';
import { LocalitiesComponent } from './localities/localities.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchComponentComponent,
    OptionsCardsComponent,
    CollectionsComponent,
    LocalitiesComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
