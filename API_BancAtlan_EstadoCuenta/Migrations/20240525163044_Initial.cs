using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_BancAtlan_EstadoCuenta.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    genero = table.Column<string>(type: "nchar(1)", fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "tipo_transaccion",
                columns: table => new
                {
                    id_tipo_transaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valor = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    concepto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_transaccion", x => x.id_tipo_transaccion);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "tarjeta",
                columns: table => new
                {
                    id_tarjeta = table.Column<int>(type: "int", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    numero = table.Column<string>(type: "varchar(16)", unicode: false, maxLength: 16, nullable: false),
                    limite_credito = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    interes = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    saldo_minimo = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    dia_corte_mes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarjeta", x => x.id_tarjeta);
                    table.ForeignKey(
                        name: "FK_tarjeta_cliente",
                        column: x => x.id_tarjeta,
                        principalTable: "cliente",
                        principalColumn: "id_cliente");
                });

            migrationBuilder.CreateTable(
                name: "estado_cuenta",
                columns: table => new
                {
                    id_estado_cuenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tarjeta = table.Column<int>(type: "int", nullable: false),
                    mes = table.Column<int>(type: "int", nullable: false),
                    anio = table.Column<int>(type: "int", nullable: false),
                    disponible = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    saldo = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    pago_minimo = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    fecha_vto_pago = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado_cuenta", x => x.id_estado_cuenta);
                    table.ForeignKey(
                        name: "FK_estado_cuenta_tarjeta",
                        column: x => x.id_tarjeta,
                        principalTable: "tarjeta",
                        principalColumn: "id_tarjeta");
                });

            migrationBuilder.CreateTable(
                name: "transaccion",
                columns: table => new
                {
                    id_transaccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tarjeta = table.Column<int>(type: "int", nullable: false),
                    fecha_transaccion = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_movimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    id_tipo_transaccion = table.Column<int>(type: "int", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    signo = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false, defaultValue: "D")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaccion", x => x.id_transaccion);
                    table.ForeignKey(
                        name: "FK_transaccion_tarjeta",
                        column: x => x.id_tarjeta,
                        principalTable: "tarjeta",
                        principalColumn: "id_tarjeta");
                    table.ForeignKey(
                        name: "FK_transaccion_tipo_transaccion",
                        column: x => x.id_tipo_transaccion,
                        principalTable: "tipo_transaccion",
                        principalColumn: "id_tipo_transaccion");
                });

            migrationBuilder.CreateIndex(
                name: "IX_estado_cuenta_id_tarjeta",
                table: "estado_cuenta",
                column: "id_tarjeta");

            migrationBuilder.CreateIndex(
                name: "IX_transaccion_id_tarjeta",
                table: "transaccion",
                column: "id_tarjeta");

            migrationBuilder.CreateIndex(
                name: "IX_transaccion_id_tipo_transaccion",
                table: "transaccion",
                column: "id_tipo_transaccion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estado_cuenta");

            migrationBuilder.DropTable(
                name: "transaccion");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "tarjeta");

            migrationBuilder.DropTable(
                name: "tipo_transaccion");

            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
