using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//namespace FestasApp
//{
//    internal static class Program
//    {
//        [STAThread]
//        static void Main()
//        {
//            var host = CreateHostBuilder().Build();
//            using (var scope = host.Services.CreateScope())
//            {
//                var services = scope.ServiceProvider;
//                Application.SetHighDpiMode(HighDpiMode.SystemAware);
//                Application.EnableVisualStyles();
//                Application.SetCompatibleTextRenderingDefault(false);
//                Application.Run(new FormMenuMain(services.GetRequiredService<clsFestasContext>()));
//            }
//        }

//        static IHostBuilder CreateHostBuilder() =>
//            Host.CreateDefaultBuilder()
//                .ConfigureServices((context, services) =>
//                {
//                    var configuration = context.Configuration;
//                    var connectionString = configuration.GetConnectionString("DefaultConnection");

//                    services.AddDbContext<clsFestasContext>(options =>
//                        options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

//                    // Adicione outros serviços necessários aqui
//                })
//                .ConfigureAppConfiguration((context, config) =>
//                {
//                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//                });
//    }
//}


namespace FestasApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            
            // FestasApp
            Application.Run(new FormMenuMain());

            // MyFramework
            //Application.Run(new MyFramework.Form1());


        }
    }
}