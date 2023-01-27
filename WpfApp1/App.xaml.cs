using System.Windows;
using FilmsChanger.Service;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsChanger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ListFilmService>();
            services.AddSingleton<AddFilmService>();
            services.AddSingleton<StatsFilmService>();
            services.AddSingleton<ChangeFilmService>();
            services.AddSingleton<SaveLoadService>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow?.Show();
        }
    }
}
