using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FluxoDiario.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "caixas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_caixas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "historico_lancamentos_caixa",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    caixa_id = table.Column<int>(type: "int", nullable: false),
                    lancamento_id = table.Column<int>(type: "int", nullable: false),
                    saldo_anterior = table.Column<double>(type: "float", nullable: false),
                    saldo_atual = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_historico_lancamentos_caixa", x => x.id);
                    table.ForeignKey(
                        name: "fk_historico_lancamentos_caixa_caixas_caixa_id",
                        column: x => x.caixa_id,
                        principalTable: "caixas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lancamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    caixa_id = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false),
                    data_lancamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lancamentos", x => x.id);
                    table.ForeignKey(
                        name: "fk_lancamentos_caixas_caixa_id",
                        column: x => x.caixa_id,
                        principalTable: "caixas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "relatorios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_caixa = table.Column<int>(type: "int", nullable: false),
                    criado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atualizado_em = table.Column<DateTime>(type: "datetime2", nullable: false),
                    data = table.Column<DateOnly>(type: "date", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    caminho_arquivo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_relatorios", x => x.id);
                    table.ForeignKey(
                        name: "fk_relatorios_caixas_id_caixa",
                        column: x => x.id_caixa,
                        principalTable: "caixas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_historico_lancamentos_caixa_caixa_id",
                table: "historico_lancamentos_caixa",
                column: "caixa_id");

            migrationBuilder.CreateIndex(
                name: "ix_lancamentos_caixa_id",
                table: "lancamentos",
                column: "caixa_id");

            migrationBuilder.CreateIndex(
                name: "ix_relatorios_id_caixa",
                table: "relatorios",
                column: "id_caixa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "historico_lancamentos_caixa");

            migrationBuilder.DropTable(
                name: "lancamentos");

            migrationBuilder.DropTable(
                name: "relatorios");

            migrationBuilder.DropTable(
                name: "caixas");
        }
    }
}
