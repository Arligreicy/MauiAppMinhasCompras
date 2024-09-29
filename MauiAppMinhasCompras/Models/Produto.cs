using System; // Importa o namespace para funcionalidades básicas do C#
using System.Collections.Generic; // Importa o namespace para coleções genéricas
using System.Linq; // Importa o namespace para funcionalidades de consulta LINQ
using System.Text; // Importa o namespace para manipulação de strings
using System.Threading.Tasks; // Importa o namespace para programação assíncrona
using SQLite; // Importa o namespace para funcionalidades do SQLite

namespace MauiAppMinhasCompras.Models
{
    // Declara a classe Produto que representa um produto na aplicação
    public class Produto
    {
        // Campos privados para armazenar dados
        string? _descricao; // Descrição do produto
        double _quantidade; // Quantidade do produto
        double _preco; // Preço do produto

        // Propriedade Id com auto incremento e chave primária
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        // Propriedade Descricao com validação
        public string? Descricao
        {
            get => _descricao; // Retorna a descrição
            set
            {
                // Valida se a descrição não é nula
                if (value == null)
                    throw new Exception("Descrição Inválida."); // Lança exceção se a descrição for nula

                _descricao = value; // Atribui o valor à descrição
            }
        }

        // Propriedade Quantidade com validação
        public double Quantidade
        {
            get => _quantidade; // Retorna a quantidade
            set
            {
                // Valida se a conversão para double é bem-sucedida
                if (!double.TryParse(value.ToString(), out _quantidade))
                    _quantidade = 0; // Define quantidade como 0 se falhar na conversão

                // Valida se a quantidade é positiva
                if (value == 0 || value < 0)
                    throw new Exception("Quantidade Inválida."); // Lança exceção se a quantidade for inválida

                _quantidade = value; // Atribui o valor à quantidade
            }
        }

        // Propriedade Preco com validação
        public double Preco
        {
            get => _preco; // Retorna o preço
            set
            {
                // Valida se a conversão para double é bem-sucedida
                if (!double.TryParse(value.ToString(), out _preco))
                    _preco = 0; // Define preço como 0 se falhar na conversão

                // Valida se o preço é positivo
                if (value <= 0)
                    throw new Exception("Preço Inválido."); // Lança exceção se o preço for inválido

                _preco = value; // Atribui o valor ao preço
            }
        }

        // Propriedade Total que calcula o total com base no preço e quantidade
        public double Total
        {
            get => Preco * Quantidade; // Retorna o produto do preço pela quantidade
        }
    }
}
