using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Platform;
using AvaloniaEdit.CodeCompletion;
using AvaloniaEdit.Highlighting;
using AvaloniaEdit.Highlighting.Xshd;
using DialogHostAvalonia;
using LiteDB.Studio.Avalonia.Dtos;
using LiteDB.Studio.Avalonia.ItemModels;
using LiteDB.Studio.Avalonia.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LiteDB.Studio.Avalonia.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            tab_querys.SelectionChanged += Tab_querys_SelectionChanged;

            Closed += MainWindow_Closed;
            dialog.Loaded += Dialog_Loaded;
        }

        private void Dialog_Loaded(object? sender, RoutedEventArgs e)
        {
            dialog.Loaded -= Dialog_Loaded;

            if (dialog.DataContext is not MainWindowViewModel vm)
            {
                return;
            }
            vm.Initialize();
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            if (this.DataContext is not MainWindowViewModel vm) 
            {
                return;
            }
            vm?.OnClosed();
        }

        private async void Tab_querys_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (tab_querys.SelectedItem is not TabItem item)
            {
                return;
            }
            if (this.DataContext is not MainWindowViewModel vm)
            {
                return;
            }
            await vm.ClearPageTaskDataResult();
            if (item.Tag is not TaskData data)
            {
                return;
            }
            _ = vm.LoadResultAsync(data);
        }

        private void btn_history_Click(object? sender, RoutedEventArgs e)
        {
            if (sender is null || sender is not Button btn)
            {
                return;
            }
            if (btn.Flyout is not MenuFlyout flyout)
            {
                return;
            }
            flyout?.ShowAt(btn);
        }

        private void DataGrid_OnCellEditEnded(object? sender, DataGridCellEditEndedEventArgs e)
        {
            var item = e.Row.DataContext;
            if (item is null)
            {
                return;
            }
        }

        private void CheckBox_Checked(object? sender, RoutedEventArgs e)
        {
            if (this.DataContext is not MainWindowViewModel vm)
            {
                return;
            }
            vm.SetConnOnAppStart(true);
        }

        private void CheckBox_Unchecked(object? sender, RoutedEventArgs e)
        {
            if (this.DataContext is not MainWindowViewModel vm)
            {
                return;
            }
            vm.SetConnOnAppStart(false);
        }
    }
}