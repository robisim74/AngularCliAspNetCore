import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-resource',
    templateUrl: './resource.component.html',
    styleUrls: ['./resource.component.scss']
})
export class ResourceComponent implements OnInit {

    values: any;

    constructor(private http: HttpClient) { }

    ngOnInit() {
        this.http.get('/api/values').subscribe(data => {
            this.values = data;
        });
    }

}
