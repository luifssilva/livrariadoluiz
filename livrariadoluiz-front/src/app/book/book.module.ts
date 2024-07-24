import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";

import { BookComponent } from "./book.component";
import { BookListComponent } from "./book-list/book-list.component";
import { BookEditComponent } from "./book-edit/book-edit.component";
import { BookAddComponent } from "./book-add/book-add.component";
import { BookRoutingModule } from "./book.routing";
import { BookService } from "../../services/book.service";



@NgModule({
    declarations: [
        BookComponent,
        BookListComponent,
        BookEditComponent,
        BookAddComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        BookRoutingModule
    ],
    providers: [
        BookService
    ],
    exports: []
})

export class BookModule { }