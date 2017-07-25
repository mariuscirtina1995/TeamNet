import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Hero } from "../hero";
import { HeroService } from "../hero.service";
import { Router } from '@angular/router';

@Component({
    selector: 'hero-list',
    templateUrl: './heroes-list.component.html',
    styleUrls: ['./heroes-list.component.css']
})
export class HeroesComponent implements OnInit {


    constructor(private heroService: HeroService, private router: Router) {
        //this.heroes = this.heroService.getHeroes();
    }

    ngOnInit(): void {
        this.getHeroes();
    }   

    heroes: Hero[];

    title = "Heroes List"

    goToHeroDetail(hero: Hero): void {
        /*daca nu e in functie ii pui this. !*/
        this.router.navigate(['/hero', hero.id]);
    }

    add(name: string): void {
        name = name.trim();
        if (!name) { return; }
        this.heroService.create(name)
            .then(hero => {
                this.heroes.push(hero);
            });
    }

    delete(hero: Hero): void {
        this.heroService
            .delete(hero.id)
            .then(() => {
                this.heroes = this.heroes.filter(h => h !== hero);
            });
    }

    /*use with promise form heroService:*/
    getHeroes(): void {
        this.heroService.getHeroes().then(heroes => this.heroes = heroes);
    }

}