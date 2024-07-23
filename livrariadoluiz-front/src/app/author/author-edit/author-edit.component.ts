import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';


import { AuthorService } from '../../../services/author.service';
import { AuthorModel } from '../../../models/author.model';

@Component({
  selector: 'app-author-edit',
  templateUrl: './author-edit.component.html',
  styleUrl: './author-edit.component.css'
})
export class AuthorEditComponent implements OnInit, OnDestroy {  
  private subscription: Subscription = new Subscription();
  id: string = '';

  authorModel: AuthorModel = {
    id: '',
    createAt: new Date(),
    name: ''
  }


  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private authorService: AuthorService) {

  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
    });

    this.subscription = this.authorService.getAuthorById(this.id).subscribe({
      next:(response) => {
        this.authorModel = response.data;
      },
      error:(response) => {
        alert(response);
      }
    });
  }

  update() {
    this.authorService.updateAuthor(this.authorModel).subscribe({
      next:(response) => {
        this.router.navigate(['author']);
      },
      error:(response) => {
        alert(response);
      }
    });
  }
}
