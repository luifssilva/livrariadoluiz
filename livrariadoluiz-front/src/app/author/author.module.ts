import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";

import { AuthorRoutingModule } from "./author.routing";
import { AuthorComponent } from "./author.component";
import { AuthorListComponent } from "./author-list/author-list.component";
import { AuthorService } from "../../services/author.service";
import { AuthorEditComponent } from './author-edit/author-edit.component';
import { AuthorAddComponent } from './author-add/author-add.component';

@NgModule({
    declarations: [
        AuthorComponent,
        AuthorListComponent,
        AuthorEditComponent,
        AuthorAddComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        AuthorRoutingModule
    ],
    providers: [
        AuthorService
    ],
    exports: []
})

export class AuthorModule { }