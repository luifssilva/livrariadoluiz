import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";

import { AuthorRoutingModule } from "./author.routing";
import { AuthorComponent } from "./author.component";
import { AuthorListComponent } from "./author-list/author-list.component";
import { AuthorService } from "../../services/author.service";

@NgModule({
    declarations: [
        AuthorComponent,
        AuthorListComponent
    ],
    imports: [
        CommonModule,
        AuthorRoutingModule
    ],
    providers: [
        AuthorService
    ],
    exports: []
})

export class AuthorModule { }