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
}
