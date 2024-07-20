import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GenderComponent } from './gender.component';
import { GenderListComponent } from './gender-list/gender-list.component';

const GenderRoutes: Routes = [
  { 
    path: 'gender', 
    component: GenderComponent,
    children: [
      { path: '', component: GenderListComponent }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(GenderRoutes)
  ],
  exports: [RouterModule]
})
export class GenderRoutingModule { }
  