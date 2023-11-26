using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueApi.Infra.Modelo
{
	internal class DataBase
	{
		/*
		 * 
		 * 
		 * 
                create database Estoque

                -- Tabela CATEGORIA
                CREATE TABLE CATEGORIA
                (
                    ID INT IDENTITY(1,1) PRIMARY KEY,
                    DESCRICAO VARCHAR(50) NOT NULL
                );

                -- Tabela PRODUTO
                CREATE TABLE PRODUTO
                (
                    ID INT IDENTITY(1,1) PRIMARY KEY,
                    DESCRICAO VARCHAR(300) NOT NULL
                );

                -- Tabela CategoriaProduto (Relacionamento muitos para muitos entre CATEGORIA e PRODUTO)
                CREATE TABLE CategoriaProduto
                (
                    CategoriasId INT NOT NULL,
                    ProdutosId INT NOT NULL,
                    PRIMARY KEY (CategoriasId, ProdutosId),
                    FOREIGN KEY (CategoriasId) REFERENCES CATEGORIA(ID) ON DELETE CASCADE,
                    FOREIGN KEY (ProdutosId) REFERENCES PRODUTO(ID) ON DELETE CASCADE
                );

                -- Tabela ESTOQUE
                CREATE TABLE ESTOQUE
                (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    ProdutoId INT NOT NULL,
                    QUATIDADE INT,
                    UNIDADE_MEDIDA INT,
                    PRECO_UNITARIO DECIMAL(16,4),
                    FOREIGN KEY (ProdutoId) REFERENCES PRODUTO(ID) ON DELETE CASCADE
                );

                -- Índices
                CREATE INDEX IX_CategoriaProduto_ProdutosId ON CategoriaProduto(ProdutosId);
                CREATE UNIQUE INDEX IX_ESTOQUE_ProdutoId ON ESTOQUE(ProdutoId);


		 * 
		 */
	}
}
