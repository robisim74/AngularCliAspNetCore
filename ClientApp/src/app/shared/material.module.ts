import { NgModule } from '@angular/core';
import {
    MatSidenavModule,
    MatToolbarModule,
    MatCardModule,
    MatListModule,
    MatButtonModule,
    MatIconModule
} from '@angular/material';

const materialModules: any[] = [
    MatSidenavModule,
    MatToolbarModule,
    MatCardModule,
    MatListModule,
    MatButtonModule,
    MatIconModule
];

@NgModule({
    imports: materialModules,
    exports: materialModules
})

export class MaterialModule { }
