import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthorModel } from '../../../models/author.model';
import { ActivatedRoute, Router } from '@angular/router';


import { AuthorService } from '../../../services/author.service';

@Component({
  selector: 'app-author-add',
  templateUrl: './author-add.component.html',
  styleUrl: './author-add.component.css'
})

export class AuthorAddComponent implements OnInit, OnDestroy {  
  private subscription: Subscription = new Subscription();

  authorModel: AuthorModel = {
    id: '00000000-0000-0000-0000-000000000000',
    name: ''
  }


  constructor(
    private router: Router,
    private authorService: AuthorService) {

  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


  ngOnInit(): void {

  }

  add() {
    this.authorService.addAuthor(this.authorModel).subscribe({
      next:(response) => {
        this.router.navigate(['author']);
      },
      error:(response) => {
        alert(response);
      }
    });
  }
}