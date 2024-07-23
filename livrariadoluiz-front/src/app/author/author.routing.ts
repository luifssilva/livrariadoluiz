import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthorComponent } from './author.component';
import { AuthorListComponent } from './author-list/author-list.component';
import { AuthorEditComponent } from './author-edit/author-edit.component';
import { AuthorAddComponent } from './author-add/author-add.component';

const AuthorRoutes: Routes = [
  { 
    path: 'author', 
    component: AuthorComponent,
    children: [
      { path: '', component: AuthorListComponent },    
      { path: 'add', component: AuthorAddComponent },    
      { path: ':id/edit', component: AuthorEditComponent }   
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(AuthorRoutes)
  ],
  exports: [RouterModule]
})
export class AuthorRoutingModule { }
  