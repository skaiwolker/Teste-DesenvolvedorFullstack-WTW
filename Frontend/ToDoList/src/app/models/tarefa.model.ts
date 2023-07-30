export interface Tarefa {
    id : string;
    titulo : string;
    descricao: string;
    dataDeInicio? : Date;
    dataDeConclusao? : Date;
    prioridade? : string;
    prioridadeId: number;
    status? : string;
}