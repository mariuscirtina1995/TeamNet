import { Injectable } from '@angular/core';
import { Http, Response, Headers } from "@angular/http";
import { Observable } from "rxjs/Rx";
import { BehaviorSubject } from "rxjs/BehaviorSubject";

import { Country } from './country';
import { PageData } from './pageData';


@Injectable()
export class CountriesService {
    constructor(private http: Http) {
    }

    getPage(pageNumber: number, pageSize: number):
        Observable<Country[]> {
        const url = `api/Countries/GetPage?pageNumber=${pageNumber}&pageSize=${pageSize}`;

        return this.http.get(url)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getPageSmart(pageNumber: number, pageSize: number):
        Observable<PageData> {
        const url = `api/Countries/GetPageSmart?pageNumber=${pageNumber}&pageSize=${pageSize}`;

        return this.http.get(url)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getNumberOfPages(pageSize: number):
        Observable<number> {
        const url = `api/Countries/GetNumberOfPages?pageSize=${pageSize}`;

        return this.http.get(url)
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || "";
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ""} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}
