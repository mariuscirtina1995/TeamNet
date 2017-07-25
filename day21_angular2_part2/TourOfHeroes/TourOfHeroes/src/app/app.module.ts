import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // <-- ng-model lives here!
import { AppComponent } from './app.component';
import { HeroService } from './hero.service';
import { HeroDetailComponent } from './heroDetail/hero-detail.component';
import { HeroesComponent } from './herolist/heroes-list.component';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from "./dashboard/dashboard.component";
import { InMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService } from './in-memory-data.service';
import { HttpModule } from '@angular/http';

const routes: Routes =
    [
        { path: "", redirectTo: "dashboard", pathMatch: 'full' },
        { path: "heroes", component: HeroesComponent },
        { path: "hero/:id", component: HeroDetailComponent },
        { path: "dashboard", component: DashboardComponent }

    ];

// https://angular.io/tutorial/toh-pt4 the forta site!

@NgModule({
    imports:
    [
        BrowserModule,
        HttpModule,
        RouterModule.forRoot(routes),
        InMemoryWebApiModule.forRoot(InMemoryDataService),
        FormsModule // <-- import the FormsModule before binding with [(ngModel)]
    ],

    declarations:
    [
        AppComponent,
        HeroDetailComponent,
        HeroesComponent,
        DashboardComponent
    ],

    bootstrap: [AppComponent],

    providers: [HeroService],

})
export class AppModule { }