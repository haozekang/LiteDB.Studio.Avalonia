using Avalonia.Controls;
using Avalonia.Input;
using LiteDB.Studio.Avalonia.ViewModels;
using System;
using System.Threading.Tasks;

namespace LiteDB.Studio.Avalonia.Views
{
    public class DialogWindow : Window
    {
        public DialogWindow(DialogViewModelBase vm)
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.Owner = App.MainWindow;
            this.Title = vm.Title;
            this.Icon = App.MainWindow?.Icon;
            this.Height = vm.Height;
            this.Width = vm.Width; 
            this.Content = vm;
            this.Closing += DialogWindow_Closing;
            this.KeyDown += DialogWindow_KeyDown;
            App.Dialogs.Add(this);
        }

        public Task<T?> ShowDialog<T>()
        {
            if (App.MainWindow is null)
            {
                return Task.FromResult<T?>(default);
            }
            return ShowDialog<T?>(App.MainWindow);
        }

        public Task ShowDialog()
        {
            if (App.MainWindow is null)
            {
                return Task.CompletedTask;
            }
            return ShowDialog(App.MainWindow);
        }

        private void DialogWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Content is not DialogViewModelBase vm)
            {
                return;
            }
            this.Closing -= DialogWindow_Closing;
            this.Close(vm.DialogResult);
        }

        private void DialogWindow_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}
