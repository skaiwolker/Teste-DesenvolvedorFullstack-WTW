using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prioridade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDeConclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrioridadeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefa_Prioridade_PrioridadeId",
                        column: x => x.PrioridadeId,
                        principalTable: "Prioridade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefa_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_PrioridadeId",
                table: "Tarefa",
                column: "PrioridadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_StatusId",
                table: "Tarefa",
                column: "StatusId");

            migrationBuilder.Sql("INSERT INTO Status(Titulo) Values('Não Iniciada')");
            migrationBuilder.Sql("INSERT INTO Status(Titulo) Values('Em Andamento')");
            migrationBuilder.Sql("INSERT INTO Status(Titulo) Values('Concluída')");

            migrationBuilder.Sql("INSERT INTO Prioridade(Titulo) Values('Baixa')");
            migrationBuilder.Sql("INSERT INTO Prioridade(Titulo) Values('Média')");
            migrationBuilder.Sql("INSERT INTO Prioridade(Titulo) Values('Alta')");

            migrationBuilder.Sql("INSERT INTO Tarefa(Descricao,PrioridadeId,StatusId,Titulo) Values('Criar sua primeira tarefa do teste do DArtagnan',3,1,'Criar a primeira tarefa')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Prioridade");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
