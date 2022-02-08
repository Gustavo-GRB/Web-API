using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto6.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PESSOA",
                columns: table => new
                {
                    CODIGO_PESSOA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SOBRENOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LOGIN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IDADE = table.Column<int>(type: "int", nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PESSOA", x => x.CODIGO_PESSOA);
                });

            migrationBuilder.CreateTable(
                name: "TB_UF",
                columns: table => new
                {
                    CODIGO_UF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SIGLA = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_UF", x => x.CODIGO_UF);
                });

            migrationBuilder.CreateTable(
                name: "TB_MUNICIPIO",
                columns: table => new
                {
                    CODIGO_MUNICIPIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    CODIGO_UF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MUNICIPIO", x => x.CODIGO_MUNICIPIO);
                    table.ForeignKey(
                        name: "FK_TB_MUNICIPIO_TB_UF_CODIGO_UF",
                        column: x => x.CODIGO_UF,
                        principalTable: "TB_UF",
                        principalColumn: "CODIGO_UF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_BAIRRO",
                columns: table => new
                {
                    CODIGO_BAIRRO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    STATUS = table.Column<int>(type: "int", nullable: false),
                    CODIGO_MUNICIPIO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BAIRRO", x => x.CODIGO_BAIRRO);
                    table.ForeignKey(
                        name: "FK_TB_BAIRRO_TB_MUNICIPIO_CODIGO_MUNICIPIO",
                        column: x => x.CODIGO_MUNICIPIO,
                        principalTable: "TB_MUNICIPIO",
                        principalColumn: "CODIGO_MUNICIPIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECO",
                columns: table => new
                {
                    CODIGO_ENDERECO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RUA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CEP = table.Column<int>(type: "int", nullable: false),
                    CODIGO_BAIRRO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ENDERECO", x => x.CODIGO_ENDERECO);
                    table.ForeignKey(
                        name: "FK_TB_ENDERECO_TB_BAIRRO_CODIGO_BAIRRO",
                        column: x => x.CODIGO_BAIRRO,
                        principalTable: "TB_BAIRRO",
                        principalColumn: "CODIGO_BAIRRO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbEnderecoTbPessoa",
                columns: table => new
                {
                    TbEnderecoCodigoEndereco = table.Column<int>(type: "int", nullable: false),
                    TbPessoaCodigoPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEnderecoTbPessoa", x => new { x.TbEnderecoCodigoEndereco, x.TbPessoaCodigoPessoa });
                    table.ForeignKey(
                        name: "FK_TbEnderecoTbPessoa_TB_ENDERECO_TbEnderecoCodigoEndereco",
                        column: x => x.TbEnderecoCodigoEndereco,
                        principalTable: "TB_ENDERECO",
                        principalColumn: "CODIGO_ENDERECO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbEnderecoTbPessoa_TB_PESSOA_TbPessoaCodigoPessoa",
                        column: x => x.TbPessoaCodigoPessoa,
                        principalTable: "TB_PESSOA",
                        principalColumn: "CODIGO_PESSOA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_BAIRRO_CODIGO_MUNICIPIO",
                table: "TB_BAIRRO",
                column: "CODIGO_MUNICIPIO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENDERECO_CODIGO_BAIRRO",
                table: "TB_ENDERECO",
                column: "CODIGO_BAIRRO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MUNICIPIO_CODIGO_UF",
                table: "TB_MUNICIPIO",
                column: "CODIGO_UF");

            migrationBuilder.CreateIndex(
                name: "IX_TbEnderecoTbPessoa_TbPessoaCodigoPessoa",
                table: "TbEnderecoTbPessoa",
                column: "TbPessoaCodigoPessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbEnderecoTbPessoa");

            migrationBuilder.DropTable(
                name: "TB_ENDERECO");

            migrationBuilder.DropTable(
                name: "TB_PESSOA");

            migrationBuilder.DropTable(
                name: "TB_BAIRRO");

            migrationBuilder.DropTable(
                name: "TB_MUNICIPIO");

            migrationBuilder.DropTable(
                name: "TB_UF");
        }
    }
}
