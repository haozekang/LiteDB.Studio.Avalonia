using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace LiteDB.Studio.Avalonia.ViewModels
{
    public partial class AboutViewModel : DialogViewModelBase
    {
        [ObservableProperty]
        private string? _author = "Zekang Hao";

        [ObservableProperty]
        private string? _email = "admin@haozekang.com";

        [ObservableProperty]
        private string? _version;

        public AboutViewModel()
        {
            _ = InitInfo();
        }

        private async Task InitInfo()
        {
            var _version = Assembly.GetEntryAssembly()?.GetName().Version;
            Version = $"{_version?.Major}.{_version?.Minor}.{_version?.Build}.{_version?.Revision}";
        }

        [RelayCommand]
        private void Ok()
        {
            Close();
        }
    }
}
