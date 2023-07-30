import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Tarefa } from 'src/app/models/tarefa.model';
import { TarefasService } from 'src/app/services/tarefas.service';

@Component({
  selector: 'app-add-tarefa',
  templateUrl: './add-tarefa.component.html',
  styleUrls: ['./add-tarefa.component.css']
})
export class AddTarefaComponent implements OnInit {
  
  addTarefaRequest: Tarefa = {
    id: '00000000-0000-0000-0000-000000000000',
    titulo: '',
    descricao: '',
    prioridadeId: 1,
  }

  constructor(private tarefasService: TarefasService, private router: Router){}

  ngOnInit(): void {
  }

  addTarefa(){
    this.tarefasService.addTarefa(this.addTarefaRequest)
    .subscribe({
      next: (addTarefa) => {
        this.router.navigate(['']);
      },
      error: (response) => {
        console.log(response)
      }
    })
  }

}
