import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule } from '@angular/forms'; // <-- ng-model lives here!

import { AppComponent } from './app.component';

import { HeroService } from './hero.service';

import { HeroDetailComponent } from './heroDetail/hero-detail.component';

// https://angular.io/tutorial/toh-pt4 the forta site!

@NgModule({
    imports:
    [
        BrowserModule,
        FormsModule // <-- import the FormsModule before binding with [(ngModel)]
    ],

    declarations:
    [
        AppComponent,
        HeroDetailComponent
    ],

    bootstrap: [AppComponent],

    providers: [HeroService],

})
export class AppModule { }
