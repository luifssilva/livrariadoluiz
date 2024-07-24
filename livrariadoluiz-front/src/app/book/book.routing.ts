import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BookComponent } from './book.component';
import { BookListComponent } from './book-list/book-list.component';
import { BookAddComponent } from './book-add/book-add.component';
import { BookEditComponent } from './book-edit/book-edit.component';

const BookRoutes: Routes = [
  { 
    path: 'book', 
    component: BookComponent,
    children: [
      { path: '', component: BookListComponent },    
      { path: 'add', component: BookAddComponent },    
      { path: ':id/edit', component: BookEditComponent }   
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(BookRoutes)
  ],
  exports: [RouterModule]
})
export class BookRoutingModule { }
  