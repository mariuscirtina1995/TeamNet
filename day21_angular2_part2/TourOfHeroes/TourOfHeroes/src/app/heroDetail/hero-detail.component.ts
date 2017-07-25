import { Component, Input, OnInit } from '@angular/core';
import { Hero } from '../Hero';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import 'rxjs/add/operator/switchMap';
import { HeroService } from "../hero.service";

@Component({
    selector: 'hero-detail',
    templateUrl: './hero-detail.component.html',
    styleUrls: ['./hero-detail.component.css']
})
export class HeroDetailComponent implements OnInit {

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private location: Location,
        private heroService: HeroService

    ) { }

    selectedHero: Hero;
    //heroes: Hero[];

    goBack(): void {
        this.location.back();
    }

    save(): void {
        this.heroService.update(this.selectedHero)
            .then(() => this.goBack());
    }

    ngOnInit(): void {
        this.route.paramMap
            .switchMap((params: ParamMap) => this.heroService.getHero(+params.get('id')))
            .subscribe(hero => this.selectedHero = hero);
    }

}