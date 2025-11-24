using CommunityToolkit.Mvvm.ComponentModel;
using LiteDB.Studio.Avalonia.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDB.Studio.Avalonia.ItemModels
{
    public partial class ConnectionItemModel : ObservableObject
    {
        [ObservableProperty]
        private bool? _isDirect = true;

        [ObservableProperty]
        private bool? _isShared = false;

        [ObservableProperty]
        private string? _filename;

        [ObservableProperty]
        private string? _password;

        [ObservableProperty]
        private string? _initSizeMB;

        [ObservableProperty]
        private string? _cultureType;

        [ObservableProperty]
        private string? _compareOption;

        [ObservableProperty]
        private bool? _isReadOnly = false;

        [ObservableProperty]
        private bool? _isUpgrade = false;
    }
}
