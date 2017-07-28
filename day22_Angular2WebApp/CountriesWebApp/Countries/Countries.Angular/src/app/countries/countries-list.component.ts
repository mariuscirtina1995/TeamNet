import { Component, OnInit } from '@angular/core';
import { CountriesService } from './countries.service';
import { Country } from './country';

@Component({
    selector: 'countries-list',
    templateUrl: './countries-list.component.html'
})
export class CountriesListComponent implements OnInit {

    countries: Country[];
    pageNumber: number = 1;
    pageSize: number = 10;
    totalPages: number = 2;
    orderBy: string = 'Code';
    countryNaneSearch: string;
    countrySearch: Country = new Country();
    searchName = false;
    filterfield: string;
    operation: string;
    valoare: string;
    saveCountry: Country = new Country();

    constructor(private service: CountriesService) {
    }

    ngOnInit(): void {
        this.refresh();
    }

    nameOrder() {
        this.orderBy = 'Name';
        this.refresh();
    }

    codeOrder() {
        this.orderBy = 'Code';
        this.refresh();
    }

    latOrder() {
        this.orderBy = 'Lat';
        this.refresh();
    }

    longOrder() {
        this.orderBy = 'Long';
        this.refresh();
    }

    searchByName() {

        this.searchName = true;

        this.service.getCountry(this.countryNaneSearch)
            .subscribe(country => {
                this.countrySearch = country;
            });
    }

    nextPage() {

        this.pageNumber++;

        this.service.getFilteresPageSmart(
            this.pageNumber
            , this.pageSize
            , this.orderBy
            , this.filterfield
            , this.operation
            , this.valoare
        )
            .subscribe(result => {
                this.countries = result.Data;
                this.totalPages = result.Total;
            });
    }

    previousPage() {

        this.pageNumber--;

        this.service.getFilteresPageSmart(
            this.pageNumber
            , this.pageSize
            , this.orderBy
            , this.filterfield
            , this.operation
            , this.valoare
        )
            .subscribe(result => {
                this.countries = result.Data;
                this.totalPages = result.Total;
            });
    }

    addCountry() {
        this.service.addCountry(this.saveCountry).subscribe(r => { });
    }

    editCountry(country: Country) {
        this.saveCountry = country;
    }

    updateCountry() {
        this.service.editCountry(this.saveCountry)
            .subscribe(r => { });
    }

    refresh() {
        if (this.pageNumber < 1) {
            alert('Nu poate fi negativ numarul paginii');
            return;
        }

        this.service.getFilteresPageSmart(
            this.pageNumber
            , this.pageSize
            , this.orderBy
            , this.filterfield
            , this.operation
            , this.valoare
        )
            .subscribe(result => {
                this.totalPages = result.Total;
            });

        if (this.pageNumber > this.totalPages) {
            alert('Numarul paginii nu poate fi mai mare decat ' + this.totalPages);
            return;
        }

        this.service.getFilteresPageSmart(
            this.pageNumber
            , this.pageSize
            , this.orderBy
            , this.filterfield
            , this.operation
            , this.valoare
        )
            .subscribe(result => {
                this.countries = result.Data;
                this.totalPages = result.Total;
                this.pageNumber = 1;
            });
    }

}
