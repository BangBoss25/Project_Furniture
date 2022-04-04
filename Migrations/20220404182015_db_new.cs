﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Project_Furniture.Migrations
{
    public partial class db_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Barang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NamaBarang = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Stok = table.Column<int>(type: "int", nullable: false),
                    Harga = table.Column<int>(type: "int", nullable: false),
                    Terjual = table.Column<int>(type: "int", nullable: false),
                    Deskripsi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Barang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Keranjang",
                columns: table => new
                {
                    Id_Keranjang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Jumlah_Pesan = table.Column<int>(type: "int", nullable: false),
                    Total_pesan = table.Column<double>(type: "double", nullable: false),
                    BarangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Keranjang", x => x.Id_Keranjang);
                    table.ForeignKey(
                        name: "FK_Tb_Keranjang_Tb_Barang_BarangId",
                        column: x => x.BarangId,
                        principalTable: "Tb_Barang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_User",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(767)", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RolesId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_User", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Tb_User_Tb_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Tb_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Pesanan",
                columns: table => new
                {
                    Id_Pesanan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tanggal_Pesan = table.Column<DateTime>(type: "datetime", nullable: false),
                    Jumlah_Pesan = table.Column<int>(type: "int", nullable: false),
                    Total_pesan = table.Column<double>(type: "double", nullable: false),
                    BarangId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Pesanan", x => x.Id_Pesanan);
                    table.ForeignKey(
                        name: "FK_Tb_Pesanan_Tb_Barang_BarangId",
                        column: x => x.BarangId,
                        principalTable: "Tb_Barang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Pesanan_Tb_User_UserName",
                        column: x => x.UserName,
                        principalTable: "Tb_User",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Tb_Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { "1", "Admin" });

            migrationBuilder.InsertData(
                table: "Tb_Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { "2", "User" });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Keranjang_BarangId",
                table: "Tb_Keranjang",
                column: "BarangId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Pesanan_BarangId",
                table: "Tb_Pesanan",
                column: "BarangId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Pesanan_UserName",
                table: "Tb_Pesanan",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_User_RolesId",
                table: "Tb_User",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Keranjang");

            migrationBuilder.DropTable(
                name: "Tb_Pesanan");

            migrationBuilder.DropTable(
                name: "Tb_Barang");

            migrationBuilder.DropTable(
                name: "Tb_User");

            migrationBuilder.DropTable(
                name: "Tb_Roles");
        }
    }
}
