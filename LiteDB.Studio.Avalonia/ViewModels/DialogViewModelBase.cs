using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDB.Studio.Avalonia.ViewModels
{
    public partial class DialogViewModelBase : ViewModelBase
    {
        public object? DialogResult { get; private set; } = null;

        [ObservableProperty]
        private string _title = string.Empty;

        [ObservableProperty]
        private double _width = 800;

        [ObservableProperty]
        private double _height = 600;

        public void SetResult(object? dialogResult)
        {
            DialogResult = dialogResult;
        }

        public void Close(object? dialogResult = null)
        {
            DialogResult = dialogResult;
            App.Dialogs.TryTake(out var dialog);
            dialog?.Close();
        }
    }
}
