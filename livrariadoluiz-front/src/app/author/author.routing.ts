import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthorComponent } from './author.component';
import { AuthorListComponent } from './author-list/author-list.component';

const AuthorRoutes: Routes = [
  { 
    path: 'author', 
    component: AuthorComponent,
    children: [
      { path: '', component: AuthorListComponent }
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
  