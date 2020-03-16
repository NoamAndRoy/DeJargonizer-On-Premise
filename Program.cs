using DeJargonizerOnPremise.Configs;
using DeJargonizerOnPremise.DeJargonizer;
using LexicalAnalyzer;
using LexicalAnalyzer.ExtensionMethods;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows.Forms;

namespace DeJargonizerOnPremise
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = new HostBuilder()
                .ConfigureAppConfiguration(ConfigureConfiguration)
                .ConfigureServices(ConfigureServices)
                .Build();

            var lexer = host.Services.GetService<ILexer<eTokenType>>();
            var deJargonizer = host.Services.GetService<IDeJargonizer>();
            Application.Run(new MainWindow(lexer, deJargonizer));

        }

        private static void ConfigureConfiguration(HostBuilderContext context, IConfigurationBuilder config)
        {
            config
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .Build();
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddOptions()
                .Configure<DataFilesConfig>(context.Configuration.GetSection("DataFiles"))
                .Configure<WordsCountThresholdsConfig>(context.Configuration.GetSection("WordsCountThresholds"));

            services.AddLexer<eTokenType>()
                .AddTransient<IWordsCountLoader, WordsCountLoader>()
                .AddTransient<IDeJargonizer, DeJargonizeAnalyzer>();
        }
    }
}
