using System; // Importa o namespace para funcionalidades básicas do C#
using System.Collections.Generic; // Importa o namespace para coleções genéricas
using System.Linq; // Importa o namespace para funcionalidades de consulta LINQ
using System.Text; // Importa o namespace para manipulação de strings
using System.Threading.Tasks; // Importa o namespace para programação assíncrona
using MauiAppMinhasCompras.Models; // Importa o namespace que contém a classe Produto
using SQLite; // Importa o namespace para funcionalidades do SQLite

namespace MauiAppMinhasCompras.Helpers
{
    // Declara a classe SQLiteDataBaseHelper, responsável por interagir com o banco de dados SQLite
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _conn; // Conexão assíncrona com o banco de dados

        // Construtor da classe que recebe o caminho do banco de dados
        public SQLiteDataBaseHelper(string path)
        {
            // Inicializa a conexão com o banco de dados
            _conn = new SQLiteAsyncConnection(path);
            // Cria a tabela Produto se ela não existir
            _conn.CreateTableAsync<Produto>().Wait();
        }

        // Método para inserir um novo produto no banco de dados
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p); // Insere o produto de forma assíncrona
        }

        // Método para atualizar um produto existente no banco de dados
        public Task<List<Produto>> Update(Produto p)
        {
            // SQL para atualizar os dados do produto
            string sql = "UPDATE Produto SET Descricao=?, " + "Quantidade=?, Preco=? WHERE id=?";

            // Executa a query de atualização
            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        // Método para recuperar todos os produtos do banco de dados
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync(); // Retorna a lista de produtos
        }

        // Método para excluir um produto do banco de dados pelo ID
        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id); // Deleta o produto com o ID especificado
        }

        // Método para buscar produtos com base na descrição
        public Task<List<Produto>> Search(string q)
        {
            // SQL para buscar produtos que contém a string de busca na descrição
            string sql = "SELECT * FROM Produto " +
                          "WHERE Descricao LIKE '%" + q + "%'";

            // Executa a query de busca
            return _conn.QueryAsync<Produto>(sql);
        }
    } // Fechamento da classe
} // Fechamento do namespace