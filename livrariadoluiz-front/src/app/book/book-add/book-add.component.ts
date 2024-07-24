import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

import { BookModelRequest } from '../../../models/book.model';
import { GenderModel } from '../../../models/gender.model';
import { AuthorModel } from '../../../models/author.model';
import { BookService } from '../../../services/book.service';
import { GenderService } from '../../../services/gender.service';
import { AuthorService } from '../../../services/author.service';



@Component({
  selector: 'app-book-add',
  templateUrl: './book-add.component.html',
  styleUrl: './book-add.component.css'
})
export class BookAddComponent implements OnInit, OnDestroy {  
  private subscription: Subscription = new Subscription();
  id: string = '';

  genders: GenderModel[] =[];
  authors: AuthorModel[] = [];

  bookModel: BookModelRequest = {
    id: '00000000-0000-0000-0000-000000000000',
    createAt: new Date(),
    name: '',
    pages: 0,
    language: '',
    edition: 0,    
    isbn: '',
    authorId: '',
    genderId: ''
  }


  constructor(
    private router: Router,
    private bookService: BookService,
    private genderService: GenderService,
    private authorService: AuthorService ) {

  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


  ngOnInit(): void {
    this.genderService.getGenders().subscribe({
      next:(response) => {
        this.genders = response.data;
      }
    });

    this.authorService.getAuthors().subscribe({
      next:(response) => {
        this.authors = response.data;
      }
    });    
  }

  add() {  
    console.log(this.bookModel);
    this.bookService.addBook(this.bookModel).subscribe({
      next:(response) => {
        this.router.navigate(['book']);
      },
      error:(response) => {
        alert(response);
      }
    });
  } 
}