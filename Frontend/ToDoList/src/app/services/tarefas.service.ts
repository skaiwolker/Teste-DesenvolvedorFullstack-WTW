import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Tarefa } from '../models/tarefa.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TarefasService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) { }

  getAllTarefasWithDetails(): Observable<Tarefa[]>{
    return this.http.get<Tarefa[]>(this.baseApiUrl + `/api/Tarefa/GetTarefasWithAllDetails`);
  }

  addTarefa(addTarefaRequest: Tarefa): Observable<Tarefa>{
    return this.http.post<Tarefa>(this.baseApiUrl + `/api/Tarefa/Add`, addTarefaRequest);
  }

  deletarTarefa(id: string){
    return this.http.delete(this.baseApiUrl + `/api/Tarefa/Delete/` + id);
  }

  iniciarTarefa(id: string){
    return this.http.head(this.baseApiUrl + `/api/Tarefa/IniciarTarefa?Id=` + id);
  }

  concluirTarefa(id: string){
    return this.http.patch(this.baseApiUrl + `/api/Tarefa/ConcluirTarefa/`, id);
  }
}
