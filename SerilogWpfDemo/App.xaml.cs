using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using LoggingLibrary;

namespace SerilogWpfDemo
{
    public partial class App : Application
    {
        public LoggerManager LoggerManager { get; private set; }

        public App()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            LoggerManager = new LoggerManager(configuration);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoggerManager.LogInformation("Application started");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            LoggerManager.LogInformation("Application is shutting down");
            LoggerManager.CloseAndFlush();
            base.OnExit(e);
        }
    }
}
