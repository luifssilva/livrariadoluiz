import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { GenderModel } from '../../../models/gender.model';
import { GenderService } from '../../../services/gender.service';

@Component({
  selector: 'app-gender-edit',
  templateUrl: './gender-edit.component.html',
  styleUrl: './gender-edit.component.css'
})
export class GenderEditComponent implements OnInit, OnDestroy {  
  private subscription: Subscription = new Subscription();
  id: string = '';

  genderModel: GenderModel = {
    id: '',
    createAt: new Date(),
    name: ''
  }


  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private genderService: GenderService) {

  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.id = params['id'];
    });

    this.subscription = this.genderService.getGenderById(this.id).subscribe({
      next:(response) => {
        this.genderModel = response.data;
      },
      error:(response) => {
        alert(response);
      }
    });
  }

  update() {
    this.genderService.updateGender(this.genderModel).subscribe({
      next:(response) => {
        this.router.navigate(['gender']);
      },
      error:(response) => {
        alert(response);
      }
    });
  }
}