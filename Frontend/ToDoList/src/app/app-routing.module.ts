import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TarefasListComponent } from './components/tarefas/tarefas-list/tarefas-list.component';
import { AddTarefaComponent } from './components/tarefas/add-tarefa/add-tarefa.component';

const routes: Routes = [
  {
    path: '',
    component: TarefasListComponent
  },
  {
    path: 'tarefa/add',
    component: AddTarefaComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
