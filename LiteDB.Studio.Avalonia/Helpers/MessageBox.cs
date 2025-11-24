using DialogHostAvalonia;
using LiteDB.Studio.Avalonia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDB.Studio.Avalonia.Helpers
{
    public static class MessageBox
    {
        public static async Task<object?> Show(string message, string? title = null, MessageViewButtons button = MessageViewButtons.Ok, MessageViewIcons icon = MessageViewIcons.None)
        {
            return await DialogHost.Show(new MessageViewModel(message, title, button, icon), "MessageBox");
        }
    }
}
