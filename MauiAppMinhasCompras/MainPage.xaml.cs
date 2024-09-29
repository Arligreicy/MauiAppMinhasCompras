using System.Collections.ObjectModel; // Importa o namespace para coleções observáveis
using MauiAppMinhasCompras.Models; // Importa o namespace que contém os modelos de dados

namespace MauiAppMinhasCompras
{
    public partial class MainPage : ContentPage
    {
        // Declara uma coleção observável de produtos
        ObservableCollection<Produto> lista_produtos = new();

        // Construtor da MainPage
        public MainPage()
        {
            InitializeComponent(); // Inicializa os componentes da página
            lst_produtos.ItemsSource = lista_produtos; // Define a fonte de itens da lista como a coleção observável
        }

        // Método chamado quando o item da toolbar para somar é clicado
        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {
            // Calcula a soma dos totais dos produtos
            double soma = lista_produtos.Sum(i => i.Total);
            // Cria uma mensagem com o total formatado
            string msg = $" O total dos produtos é {soma:C}";
            // Exibe um alerta com o resultado
            DisplayAlert("Resultado", msg, "Fechar");
        }

        // Método assíncrono chamado quando o item da toolbar para adicionar é clicado
        private async void ToolbarItem_Clicked_Add(object sender, EventArgs e)
        {
            // Navega para a página de adicionar um novo produto
            await Navigation.PushAsync(new Views.NovoProduto());
        }

        // Método chamado quando a página aparece
        protected async override void OnAppearing()
        {
            // Se a lista de produtos estiver vazia
            if (lista_produtos.Count == 0)
            {
                // Obtém todos os produtos do banco de dados
                List<Produto> tmp = await App.Database.GetAll();
                // Adiciona cada produto à coleção observável
                foreach (Produto p in tmp)
                {
                    lista_produtos.Add(p);
                }
            } // Fecha o if
        } // Fecha o método

        // Método chamado quando o texto da busca é alterado
        protected async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Obtém o novo valor do texto de busca
            string q = e.NewTextValue;
            // Limpa a coleção de produtos
            lista_produtos.Clear();
            // Procura produtos no banco de dados com base no texto de busca
            List<Produto> tmp = await App.Database.Search(q);
            // Adiciona os produtos encontrados à coleção observável
            foreach (Produto p in tmp)
            {
                lista_produtos.Add(p);
            }
        } // Fecha o método

        // Método chamado quando um item da lista de produtos é selecionado
        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Obtém o produto selecionado
            Produto? p = e.SelectedItem as Produto;
            // Navega para a página de edição de produto, passando o produto selecionado como contexto de binding
            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p,
            });
        } // Fecha o método

        // Método assíncrono chamado quando um item de menu é clicado
        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Obtém o item de menu clicado
                MenuItem selecionado = sender as MenuItem;
                // Obtém o produto associado ao item de menu
                Produto p = selecionado.BindingContext as Produto;

                // Exibe um alerta de confirmação para remover o produto
                bool confirm = await DisplayAlert("Tem Certeza?", "Remover Produto?", "Sim", "Não");
                if (confirm)
                {
                    // Remove o produto do banco de dados
                    await App.Database.Delete(p.Id);
                    // Exibe um alerta de sucesso
                    await DisplayAlert("Sucesso!", "Produto Removido", "OK");
                    // Remove o produto da coleção observável
                    lista_produtos.Remove(p);
                }
            }
            catch (Exception ex)
            {
                // Exibe um alerta de erro
                await DisplayAlert("Ops", ex.Message, "Fechar");
            }
        } // Fecha o método

    } // Fecha a classe

} // Fecha o namespace
