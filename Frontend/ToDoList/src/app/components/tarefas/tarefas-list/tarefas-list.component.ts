import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Tarefa } from 'src/app/models/tarefa.model';
import { TarefasService } from 'src/app/services/tarefas.service';

@Component({
  selector: 'app-tarefas-list',
  templateUrl: './tarefas-list.component.html',
  styleUrls: ['./tarefas-list.component.css']
})
export class TarefasListComponent implements OnInit {

  tarefas: Tarefa[] = [];

  constructor(private tarefasService: TarefasService, private router: Router) { }

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

  deletarTarefa(id: string){
    this.tarefasService.deletarTarefa(id)
    .subscribe({
      next: () => {
        this.tarefasService.getAllTarefasWithDetails()
        .subscribe({
          next: (tarefas) => {
            this.tarefas = tarefas;
          },
        })
      },
      error: (response) => {
        console.log(response)
      }
    })
  }

  iniciarTarefa(id: string){
    this.tarefasService.iniciarTarefa(id)
    .subscribe({
      next: () => {
        this.tarefasService.getAllTarefasWithDetails()
        .subscribe({
          next: (tarefas) => {
            this.tarefas = tarefas;
          },
        })
      },
      error: (response) => {
        console.log(response)
      }
    })
  }

  concluirTarefa(id: string){
    this.tarefasService.concluirTarefa(id)
    .subscribe({
      next: () => {
        this.tarefasService.getAllTarefasWithDetails()
        .subscribe({
          next: (tarefas) => {
            this.tarefas = tarefas;
          },
        })
      },
      error: (response) => {
        console.log(response)
      }
    })
  }

}
