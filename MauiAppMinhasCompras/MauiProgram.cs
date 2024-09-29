using Microsoft.Extensions.Logging; // Importa o namespace para funcionalidades de logging

namespace MauiAppMinhasCompras
{
    public static class MauiProgram
    {
        // Método estático que cria e configura a aplicação MAUI
        public static MauiApp CreateMauiApp()
        {
            // Cria um construtor para configurar a aplicação MAUI
            var builder = MauiApp.CreateBuilder();
            builder
                // Configura a aplicação principal utilizando a classe App
                .UseMauiApp<App>()
                // Configura as fontes da aplicação
                .ConfigureFonts(fonts =>
                {
                    // Adiciona a fonte "OpenSans-Regular.ttf" com o nome "OpenSansRegular"
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    // Adiciona a fonte "OpenSans-Semibold.ttf" com o nome "OpenSansSemibold"
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            #if DEBUG
            // Se estiver em modo DEBUG, adiciona o provedor de logs de depuração
            builder.Logging.AddDebug();
            #endif

            // Constrói e retorna a instância configurada da aplicação MAUI
            return builder.Build();
        }
    }
}
