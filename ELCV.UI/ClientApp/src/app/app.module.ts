import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CountryModule } from './country-module/country.module';
import { NotFoundInterceptor } from './interceptors/not-found.interceptor';
import { NotFoundComponent } from './not-found/not-found.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full'},
      { path: 'counter', component: CounterComponent},
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'not-found', component:NotFoundComponent  },
    ]),
    CountryModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: NotFoundInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
