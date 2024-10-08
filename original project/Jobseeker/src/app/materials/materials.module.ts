import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatMenuModule} from '@angular/material/menu';
// import { MatSidenav } from '@angular/material/sidenav';
import { MatDividerModule } from '@angular/material/divider';
import { MatDialogModule } from '@angular/material/dialog';
import {MatTabsModule} from '@angular/material/tabs';
import { MatOptionModule } from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import {MatChipsModule} from '@angular/material/chips';


const materialArray=[
  MatInputModule,MatFormFieldModule,MatIconModule,MatButtonModule,
  MatToolbarModule,MatSidenavModule,
  MatDividerModule,MatMenuModule,MatDialogModule,MatTabsModule,MatFormFieldModule,MatOptionModule,MatSelectModule,MatChipsModule
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,materialArray
  ],
  exports:[materialArray]
})
export class MaterialsModule { }
