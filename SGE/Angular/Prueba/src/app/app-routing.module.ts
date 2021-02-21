import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListadoComponent } from './listado/listado.component';
import { TablaPersonasComponent } from './tabla-personas/tabla-personas.component';

const routes: Routes = [
  {path: 'tabla-personas', component: TablaPersonasComponent},
  {path: 'listado', component: ListadoComponent},
  {path: '', redirectTo: '/tabla-personas', pathMatch: 'full'}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
