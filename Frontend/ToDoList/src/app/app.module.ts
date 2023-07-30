import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TarefasListComponent } from './components/tarefas/tarefas-list/tarefas-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddTarefaComponent } from './components/tarefas/add-tarefa/add-tarefa.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    TarefasListComponent,
    AddTarefaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
