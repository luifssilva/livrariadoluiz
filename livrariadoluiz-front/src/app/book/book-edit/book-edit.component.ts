import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';

import { BookModelRequest } from '../../../models/book.model';
import { BookService } from '../../../services/book.service';
import { GenderModel } from '../../../models/gender.model';
import { GenderService } from '../../../services/gender.service';
import { AuthorService } from '../../../services/author.service';
import { AuthorModel } from '../../../models/author.model';


@Component({
  selector: 'app-book-edit',
  templateUrl: './book-edit.component.html'
})
export class BookEditComponent implements OnInit, OnDestroy {  
  private subscription: Subscription = new Subscription();
  id: string = '';

  genders: GenderModel[] =[];
  authors: AuthorModel[] = [];

  bookModel: BookModelRequest = {
    id: '',
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
    private activatedRoute: ActivatedRoute,
    private bookService: BookService,
    private genderService: GenderService,
    private authorService: AuthorService ) {

  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
    });

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

    this.subscription = this.bookService.getBookById(this.id).subscribe({
      next:(response) => {
        this.bookModel = response.data;
      },
      error:(response) => {
        alert(response);
      }
    });
  }

  update() {        
    this.bookService.updateBook(this.bookModel).subscribe({
      next:(response) => {
        this.router.navigate(['book']);
      },
      error:(response) => {
        alert(response);
      }
    });
  } 
}