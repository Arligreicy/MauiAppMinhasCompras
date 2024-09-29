using MauiAppMinhasCompras.Helpers; // Importa o namespace que contém a classe SQLiteDataBaseHelper
using System.IO; // Importa o namespace para funcionalidades de entrada e saída de arquivos

namespace MauiAppMinhasCompras
{
    // Declara a classe App que herda de Application
    public partial class App : Application
    {
        // Declara uma variável estática para o banco de dados
        static SQLiteDataBaseHelper database;

        // Propriedade estática que retorna uma instância do banco de dados
        public static SQLiteDataBaseHelper Database
        {
            get
            {
                // Se a instância do banco de dados for nula, cria uma nova instância
                if (database == null)
                {
                    // Define o caminho para o arquivo do banco de dados
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "arquivo.db3");
                    // Cria uma nova instância do banco de dados com o caminho definido
                    database = new SQLiteDataBaseHelper(path);
                }
                // Retorna a instância do banco de dados
                return database;
            }
        }

        // Construtor da classe App
        public App()
        {
            // Inicializa os componentes da aplicação definidos no arquivo XAML associado
            InitializeComponent();

            // Define a cultura atual do thread para "pt-BR"
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pt-BR");

            // Define a página principal da aplicação como AppShell
            MainPage = new AppShell();
        }
    }
}
