import { Component, OnInit } from '@angular/core';
import { CountriesService } from './countries.service';
import { Country } from './country';
@Component({
    selector: 'countries-list',
    templateUrl: './countries-list.component.html'
})
export class CountriesListComponent implements OnInit {

    countries: Country[];
    pageNumber: number = 0
    pageSize: number = 10;
    totalPages: number = 0;

    constructor(private service: CountriesService) {
    }

    ngOnInit(): void {
        this.refresh();


    }

    refresh() {
        if (this.pageNumber < 0) {
            alert('Nu poate fi negativ numarul paginii');
            return;
        }

        this.service.getNumberOfPages(this.pageSize)
            .subscribe(totalPages => {
                this.totalPages = totalPages;

                if (this.pageNumber > this.totalPages) {
                    alert('Numarul paginii nu poate fi mai mare decat ' + this.totalPages);
                    return;
                }

                this.service.getPageSmart(this.pageNumber, this.pageSize)
                    .subscribe(result => {
                        this.countries = result.Data;
                    });
            });




    }
}
