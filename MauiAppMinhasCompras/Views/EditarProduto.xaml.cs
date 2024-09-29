using MauiAppMinhasCompras.Models; // Importa o namespace que cont�m a classe Produto
using System.Runtime.CompilerServices; // Importa o namespace para funcionalidades de compila��o, n�o usado neste trecho

namespace MauiAppMinhasCompras.Views
{
    // Declara a classe EditarProduto que herda de ContentPage
    public partial class EditarProduto : ContentPage
    {
        // Construtor da classe EditarProduto
        public EditarProduto()
        {
            InitializeComponent(); // Inicializa os componentes da p�gina definidos no arquivo XAML associado
        }

        // M�todo ass�ncrono chamado quando o item da toolbar � clicado
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obt�m o produto anexado ao contexto de binding
                Produto produto_anexado = BindingContext as Produto;

                // Cria uma nova inst�ncia de Produto com os valores atualizados
                Produto p = new Produto()
                {
                    Id = produto_anexado.Id, // Mant�m o ID do produto original
                    Descricao = txt_descricao.Text, // Obt�m a descri��o do campo de texto
                    Preco = Convert.ToDouble(txt_preco.Text), // Converte o pre�o do campo de texto para double
                    Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte a quantidade do campo de texto para double
                };

                // Atualiza o produto no banco de dados
                await App.Database.Update(p);
                // Exibe um alerta de sucesso
                await DisplayAlert("Sucesso", "Atualizado", "OK");
                // Navega de volta para a p�gina principal
                await Navigation.PushAsync(new MainPage()); // Navega entre telas
            }
            catch (Exception ex)
            {
                // Exibe um alerta de erro com a mensagem da exce��o
                await DisplayAlert("Ops", ex.Message, "Fechar");
            } // Fecha o bloco try
        } // Fecha o m�todo
    } // Fecha a classe
} // Fecha o namespace