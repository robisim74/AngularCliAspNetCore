import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ResourceRoutingModule } from './resource-routing.module';
import { SharedModule } from '../shared/shared.module';

import { ResourceComponent } from './resource.component';

@NgModule({
    imports: [
        CommonModule,
        ResourceRoutingModule,
        SharedModule
    ],
    declarations: [ResourceComponent]
})
export class ResourceModule { }
