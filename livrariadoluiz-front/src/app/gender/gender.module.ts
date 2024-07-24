import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { GenderComponent } from "./gender.component";
import { GenderListComponent } from "./gender-list/gender-list.component";
import { GenderRoutingModule } from "./gender.routing";
import { GenderAddComponent } from './gender-add/gender-add.component';
import { GenderEditComponent } from './gender-edit/gender-edit.component';
import { FormsModule } from "@angular/forms";

@NgModule({
    declarations: [
        GenderComponent,
        GenderListComponent,
        GenderAddComponent,
        GenderEditComponent        
    ],
    imports: [
        CommonModule,
        FormsModule,
        GenderRoutingModule
    ],
    exports: []
})

export class GenderModule { }