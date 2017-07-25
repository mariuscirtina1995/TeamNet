import { Component } from '@angular/core';

import { OnInit } from '@angular/core';

import { FormsModule } from '@angular/forms';

import { Hero } from './hero';

import { HeroService } from './hero.service';

// gen atribut din c#
@Component({
    selector: 'my-app', 
    templateUrl: './app.component.html',
  
})
export class AppComponent implements OnInit {
    name = 'Angular';
    title = 'Tour of Heroes';

    firsthero: Hero = {
        id: 1,
        name: 'Windstorm'
    };

    heroes: Hero[];

    selectedHero: Hero;

    constructor(private heroService: HeroService)
    {
        //this.heroes = this.heroService.getHeroes();

    }

    onSelect(hero: Hero): void {
        //daca nu e in functie ii pui this. !
        this.selectedHero = hero;
    }

    //getHeroes(): void {
    //    this.heroes = this.heroService.getHeroes();
    //}


    //use with promise form heroService:
    getHeroes(): void {
        this.heroService.getHeroes().then(heroes => this.heroes = heroes);
    }

    ngOnInit(): void {
         this.getHeroes();
    }

}


