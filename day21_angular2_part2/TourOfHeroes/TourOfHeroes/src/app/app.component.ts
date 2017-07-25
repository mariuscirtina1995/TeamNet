import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Hero } from './hero';
import { HeroService } from './hero.service';

// gen atribut din c#
@Component({
    selector: 'my-app', 
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'Tour of Heroes';
}


