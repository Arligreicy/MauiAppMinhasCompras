using MauiAppMinhasCompras.Models; // Importa o namespace que cont�m a classe Produto

namespace MauiAppMinhasCompras.Views
{
    // Declara a classe NovoProduto que herda de ContentPage
    public partial class NovoProduto : ContentPage
    {
        // Construtor da classe NovoProduto
        public NovoProduto()
        {
            // Inicializa os componentes da p�gina definidos no arquivo XAML associado
            InitializeComponent();
        }

        // M�todo ass�ncrono chamado quando o item da toolbar � clicado
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Cria uma nova inst�ncia de Produto com os valores dos campos de entrada
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text),
                };
                // Insere o novo produto no banco de dados
                await App.Database.Insert(p);
                // Exibe um alerta de sucesso
                await DisplayAlert("Sucesso!", "Produto Inserido", "Ok");
                // Navega para a p�gina principal
                await Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                // Exibe um alerta de erro com a mensagem da exce��o
                await DisplayAlert("Ops", ex.Message, "Fechar");
            }
        }
    }
}