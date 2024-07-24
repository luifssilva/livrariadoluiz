import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { BookService } from '../../../services/book.service';
import { BookModel } from '../../../models/book.model';


@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrl: './book-list.component.css'
})
export class BookListComponent implements OnInit, OnDestroy {
  private subscription: Subscription = new Subscription();
  books: BookModel[] = [];
  
  constructor(
    private router: Router,
    private bookService: BookService) {
  }

  ngOnInit(): void {
    this.getBooks();
  } 

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  } 
  
  add() {
    this.router.navigate(['book', 'add']);
  }

  getBooks() {
    this.subscription = this.bookService.getBooks().subscribe({
      next:(response) => {
        this.books = response.data;
      }
    });    
  }

  edit(id: string) {
    this.router.navigate(['book', id, 'edit']);
  }
  remove(id: string) {
    this.subscription = this.bookService.deleteBook(id).subscribe({
      next:() => {
        this.getBooks();
      },
      error:(response) => {
        alert(response);
      }
    });    
  }  
}
