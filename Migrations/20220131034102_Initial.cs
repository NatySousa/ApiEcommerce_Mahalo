using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Desafio_Angular.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.IdCliente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IdProduto = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Foto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IdProduto);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Logradouro = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cidade = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Estado = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCliente = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.IdEndereco);
                    table.ForeignKey(
                        name: "FK_endereco_cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DataPedido = table.Column<DateTime>(type: "date", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCliente = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdEndereco = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ItemPedido",
                columns: table => new
                {
                    IdItemPedido = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdPedido = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdProduto = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    QuantidadeProduto = table.Column<int>(type: "int", nullable: false),
                    ValorUnitarioProduto = table.Column<float>(type: "float", nullable: false),
                    ValorTotalItem = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPedido", x => x.IdItemPedido);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPedido_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "01c73ca4-4d3e-408e-b2d3-1bf550325d2f", "Poltrona Balanço", 5360.00, 3, "Un", "e7df8367-3288-4566-8057-cf4ce7e5f601.jpg"}
                        );

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "24119d46-9a63-4695-bf75-862c9e6ca2c6", "Cama Queen", 3490.00, 8, "Un", "a6265cb3-0dbf-4b04-84fe-796372e40b4a.jpg"}
                        );

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "2dea15cb-2fe0-4d96-a40a-3cec6d979a09", "Cadeira Presidente", 1489.00, 10, "Un", "32a8cd13-c5f8-414e-a03c-f34e9a2ff130.jpg"}
                        );

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "352de47f-da70-4dc2-ab13-9205ac31280b", "Poltrona Lulu", 960.00, 3, "Un", "009308b6-ae75-452a-ac2a-3c14a0839504.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "4f56e648-0b56-4c06-b050-0a72c51c2722", "Cadeira Gamer", 1975.00, 5, "Un", "f04f7e51-d6ae-4464-94cd-b509effd46af.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "59ec5d4d-48cf-41c2-82bc-dff45bfc14f0", "Mesa Bureau", 1800.00, 5, "Un", "c898fec3-c6bd-404e-8a22-7abdf5adeccc.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "674f03f5-3dde-4430-a1a1-19fe3f559e09", "Sofá Family", 3100.00, 10, "Un", "53ba1da3-d096-4db5-8c84-c45f8cb0b9db.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "6a12fba3-e2ba-4aa1-b84e-2ef82e434409", "Poltrona Divã", 1248.00, 16, "Un", "e8e51d03-483b-433d-81e7-bf4ef04a8cef.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "921ac1d2-e9d0-41cb-960c-759900c37cf4", "Mesa Duo", 870.00, 8, "Un", "734520e0-df88-462b-8a2e-20073e72ec82.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "9d411ac5-393c-4f61-8c5c-0a25424ce260", "Cadeira do Papai", 1590.00, 10, "Un", "cd122c2c-136a-433f-a610-9828412fadce.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "b7bf66c6-b0f2-4ff5-b029-684dfe96f7f8", "Cama Solteiro", 560.00, 1, "Un", "c6faf241-0990-4b06-8a4a-f53ffa0c816e.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "beee035c-9b72-42b6-a0bc-60203d69d7aa", "Cama Multi", 1590.00, 1, "Un", "d7021694-200d-4681-8757-6176d4a7bc14.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "c5cfba11-53d0-4590-a88f-9d11224b6c0a", "Mesa Bureau", 1800.00, 4, "Un", "5f57592d-47a8-4d14-9c10-df4c440fe21d.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "ca7e7737-4caa-465b-9ee9-3899bb0ec143", "Mesa Gaia", 870.00, 8, "Un", "3d00c46f-5bd8-458a-9d47-fba51934475e.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "cd6443d4-fe8f-4dfc-bcb9-9b81aa1c65f5", "Mesa Cozynero", 6360.00, 9, "Un", "0ff868b3-aaba-4078-a997-fa9ab14377d5.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "cd809183-6548-4bac-bb33-04d1ab440755", "Mesa Gamer", 1230.00, 15, "Un", "9950b3f0-c685-4e90-b538-0c08d3bd39ac.jpg"}
                        ); 

            migrationBuilder.InsertData(
                        table: "produto",
                        columns: new[] { "IdProduto", "Nome", "Preco", "Quantidade", "UnidadeMedida", "Foto" },
                        values: new object[] { "eb344362-3ea8-4b0d-ae37-26d55f67aba1", "Sofá Ibirapuera", 2000.00, 4, "Un", "ff72997b-edb5-451c-b94c-488c497a07db.jpg"}
                        ); 


            migrationBuilder.CreateIndex(
                name: "IX_cliente_Cpf",
                table: "cliente",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_Email",
                table: "cliente",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_endereco_IdCliente",
                table: "endereco",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_IdPedido",
                table: "ItemPedido",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPedido_IdProduto",
                table: "ItemPedido",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdEndereco",
                table: "Pedido",
                column: "IdEndereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
