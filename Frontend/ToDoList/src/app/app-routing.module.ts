import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TarefasListComponent } from './components/tarefas/tarefas-list/tarefas-list.component';

const routes: Routes = [
  {
    path: '',
    component: TarefasListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
