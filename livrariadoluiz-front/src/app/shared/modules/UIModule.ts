import { NgModule } from "@angular/core";
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';

@NgModule({
    declarations: [],
    imports: [
        MatSidenavModule,
        MatMenuModule,
        MatButtonModule,
        MatToolbarModule,
        MatTableModule
    ],
    exports: [
        MatSidenavModule,
        MatMenuModule,
        MatButtonModule,
        MatToolbarModule,
        MatTableModule
    ]
})

export class UIModule { }