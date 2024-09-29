using MauiAppMinhasCompras.Models; // Importa o namespace que contém a classe Produto
using System.Runtime.CompilerServices; // Importa o namespace para funcionalidades de compilação, não usado neste trecho

namespace MauiAppMinhasCompras.Views
{
    // Declara a classe EditarProduto que herda de ContentPage
    public partial class EditarProduto : ContentPage
    {
        // Construtor da classe EditarProduto
        public EditarProduto()
        {
            InitializeComponent(); // Inicializa os componentes da página definidos no arquivo XAML associado
        }

        // Método assíncrono chamado quando o item da toolbar é clicado
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtém o produto anexado ao contexto de binding
                Produto produto_anexado = BindingContext as Produto;

                // Cria uma nova instância de Produto com os valores atualizados
                Produto p = new Produto()
                {
                    Id = produto_anexado.Id, // Mantém o ID do produto original
                    Descricao = txt_descricao.Text, // Obtém a descrição do campo de texto
                    Preco = Convert.ToDouble(txt_preco.Text), // Converte o preço do campo de texto para double
                    Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte a quantidade do campo de texto para double
                };

                // Atualiza o produto no banco de dados
                await App.Database.Update(p);
                // Exibe um alerta de sucesso
                await DisplayAlert("Sucesso", "Atualizado", "OK");
                // Navega de volta para a página principal
                await Navigation.PushAsync(new MainPage()); // Navega entre telas
            }
            catch (Exception ex)
            {
                // Exibe um alerta de erro com a mensagem da exceção
                await DisplayAlert("Ops", ex.Message, "Fechar");
            } // Fecha o bloco try
        } // Fecha o método
    } // Fecha a classe
} // Fecha o namespace