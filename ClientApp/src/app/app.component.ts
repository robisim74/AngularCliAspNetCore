import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

    navItems: any[] = [
        { name: 'Home', route: 'home' },
        { name: 'Resource', route: 'resource' }
    ];

    constructor(public title: Title) { }

    ngOnInit(): void {
        this.title.setTitle('Angular CLI ASP.NET Core');
    }

}
