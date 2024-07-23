import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { GenderComponent } from './gender.component';
import { GenderListComponent } from './gender-list/gender-list.component';
import { GenderAddComponent } from './gender-add/gender-add.component';
import { GenderEditComponent } from './gender-edit/gender-edit.component';

const GenderRoutes: Routes = [
  { 
    path: 'gender', 
    component: GenderComponent,
    children: [
      { path: '', component: GenderListComponent },
      { path: 'add', component: GenderAddComponent },    
      { path: ':id/edit', component: GenderEditComponent }         
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
  