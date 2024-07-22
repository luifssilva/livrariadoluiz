import { Component, OnInit } from '@angular/core';
import { AuthorService } from '../../../services/author.service';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrl: './author-list.component.css'
})
export class AuthorListComponent implements OnInit {

  constructor(private authorService: AuthorService) {

  }
  ngOnInit(): void {
    this.authorService.getAuthors().subscribe({
      next:(response => {
        console.log(response);
      })
    });
  }

}
