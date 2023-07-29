import { Component, OnInit } from '@angular/core';
import { Tarefa } from 'src/app/models/tarefa.model';
import { TarefasService } from 'src/app/services/tarefas.service';

@Component({
  selector: 'app-tarefas-list',
  templateUrl: './tarefas-list.component.html',
  styleUrls: ['./tarefas-list.component.css']
})
export class TarefasListComponent implements OnInit {

  tarefas: Tarefa[] = [];

  constructor(private tarefasService: TarefasService) { }

  ngOnInit(): void {
    this.tarefasService.getAllTarefasWithDetails()
    .subscribe({
      next: (tarefas) => {
        this.tarefas = tarefas;
      },
      error: (response) => {
        console.log(response)
      }
    })
  }

}
