using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using LiteDB.Studio.Avalonia.ViewModels;
using LiteDB.Studio.Avalonia.Views;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace LiteDB.Studio.Avalonia
{
    public partial class App : Application
    {
        public static Window? MainWindow
        {
            get
            {
                if (App.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                {
                    return desktop.MainWindow;
                }
                return null;
            }
        }

        public static DirectoryInfo AppDataDirectory
        {
            get
            {
                return new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LiteDBStudioAvalonia"));
            }
        }

        public static DirectoryInfo AppLogsDirectory
        {
            get
            {
                return new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LiteDBStudioAvalonia", "Logs"));
            }
        }

        public static DirectoryInfo AppExeDirectory
        {
            get
            {
                return new DirectoryInfo(Environment.CurrentDirectory);
            }
        }

        public static BlockingCollection<Window> Dialogs
        {
            get;
        } = new BlockingCollection<Window>(new ConcurrentStack<Window>());

        public override void Initialize()
        {
            if (AppLogsDirectory.Exists != true)
            {
                try
                {
                    AppLogsDirectory.Create();
                }
                catch
                {
                    Environment.Exit(1);
                }
            }
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console(
                outputTemplate: "[{Level}] {Message}{NewLine}{Exception}")
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug || e.Level == LogEventLevel.Information)

            .WriteTo.File(
                path: "Logs/log-.txt",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 30,
                restrictedToMinimumLevel: LogEventLevel.Warning,
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level}] {Message}{NewLine}{Exception}")
            .CreateLogger();

            AvaloniaXamlLoader.Load(this);

            if (AppDataDirectory.Exists != true)
            {
                try 
                {
                    AppDataDirectory.Create();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                    Environment.Exit(1);
                }
            }
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                DisableAvaloniaDataAnnotationValidation();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }
    }
}