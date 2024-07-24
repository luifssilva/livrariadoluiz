import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { GenderModel } from '../../../models/gender.model';
import { GenderService } from '../../../services/gender.service';



@Component({
  selector: 'app-gender-add',
  templateUrl: './gender-add.component.html'
})
export class GenderAddComponent implements OnInit, OnDestroy {  
  private subscription: Subscription = new Subscription();

  genderModel: GenderModel = {
    id: '00000000-0000-0000-0000-000000000000',
    name: ''
  }


  constructor(
    private router: Router,
    private genderService: GenderService) {

  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


  ngOnInit(): void {

  }

  add() {
    this.genderService.addGender(this.genderModel).subscribe({
      next:(response) => {
        this.router.navigate(['gender']);
      },
      error:(response) => {
        alert(response);
      }
    });
  }
}
