import { Component, OnDestroy, OnInit } from '@angular/core';
import { GenderModel } from '../../../models/gender.model';
import { GenderService } from '../../../services/gender.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-gender-list',
  templateUrl: './gender-list.component.html',
  styleUrl: './gender-list.component.css'
})
export class GenderListComponent implements OnInit, OnDestroy {
  private subscription: Subscription = new Subscription();
  genders: GenderModel[] = [];
  
  constructor(
    private router: Router,
    private genderService: GenderService) {
  }

  ngOnInit(): void {
    this.getGenders();
  } 

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  } 
  
  add() {
    this.router.navigate(['gender', 'add']);
  }

  getGenders() {
    this.subscription = this.genderService.getGenders().subscribe({
      next:(response) => {
        this.genders = response.data;
      }
    });    
  }

  edit(id: string) {
    this.router.navigate(['author', id, 'edit']);
  }
  remove(id: string) {
    this.subscription = this.genderService.deleteGender(id).subscribe({
      next:() => {
        this.getGenders();
      },
      error:(response) => {
        alert(response);
      }
    });    
  }  
}
