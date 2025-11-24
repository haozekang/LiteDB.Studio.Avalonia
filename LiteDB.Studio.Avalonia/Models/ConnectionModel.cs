using CommunityToolkit.Mvvm.ComponentModel;
using LiteDB.Studio.Avalonia.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDB.Studio.Avalonia.Models
{
    public partial class ConnectionModel : ObservableObject
    {
        [ObservableProperty]
        private ConnectionItemModel? _item;

        public ConnectionModel()
        {
            _item = new();
        }
    }
}
