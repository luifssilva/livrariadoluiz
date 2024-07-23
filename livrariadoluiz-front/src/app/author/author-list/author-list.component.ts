import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

import { AuthorService } from '../../../services/author.service';
import { AuthorModel } from '../../../models/author.model';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrl: './author-list.component.css'
})
export class AuthorListComponent implements OnInit, OnDestroy {
  private subscription: Subscription = new Subscription();
  authors: AuthorModel[] = [];
  
  constructor(
    private router: Router,
    private authorService: AuthorService) {
  }

  ngOnInit(): void {
    this.getAuthors();
  } 

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  } 
  
  add() {
    this.router.navigate(['author', 'add']);
  }

  getAuthors() {
    this.subscription = this.authorService.getAuthors().subscribe({
      next:(response) => {
        this.authors = response.data;
      }
    });    
  }

  edit(id: string) {
    this.router.navigate(['author', id, 'edit']);
  }
  remove(id: string) {
    this.subscription = this.authorService.deleteAuthor(id).subscribe({
      next:() => {
        this.getAuthors();
      },
      error:(response) => {
        alert(response);
      }
    });    
  }  
}
