import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { GenderComponent } from "./gender.component";
import { GenderListComponent } from "./gender-list/gender-list.component";
import { GenderRoutingModule } from "./gender.routing";

@NgModule({
    declarations: [
        GenderComponent,
        GenderListComponent
    ],
    imports: [
        CommonModule,
        GenderRoutingModule
    ],
    exports: []
})

export class GenderModule { }