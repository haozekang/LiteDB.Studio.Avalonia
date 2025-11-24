using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LiteDB.Studio.Avalonia.ViewModels
{
    public partial class MessageViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string? _message;

        [ObservableProperty]
        private MessageViewButtons _button;

        [ObservableProperty]
        private string? _title;

        [ObservableProperty]
        private MessageViewIcons _icon;

        [ObservableProperty]
        private bool _isIconShow = false;

        [ObservableProperty]
        private bool _isTitleShow = false;

        [ObservableProperty]
        private bool _isOkVisible = true;

        [ObservableProperty]
        private bool _isCancelVisible = false;

        [ObservableProperty]
        private bool _isYesVisible = false;

        [ObservableProperty]
        private bool _isNoVisible = false;

        [ObservableProperty]
        private string _iconText = string.Empty;

        [ObservableProperty]
        private IBrush _iconForeground = Brushes.Transparent;

        public MessageViewModel(string message, string? title = null, MessageViewButtons button = MessageViewButtons.Ok, MessageViewIcons icon = MessageViewIcons.None) 
        {
            _message = message;
            _button = button;
            _title = title;
            _icon = icon;

            IsOkVisible = button.HasFlag(MessageViewButtons.Ok);
            IsCancelVisible = button.HasFlag(MessageViewButtons.Cancel);
            IsYesVisible = button.HasFlag(MessageViewButtons.Yes);
            IsNoVisible = button.HasFlag(MessageViewButtons.No);

            IconText = icon switch
            {
                MessageViewIcons.Asterisk => "\xe6a6",
                MessageViewIcons.Information => "\xe6a3",
                MessageViewIcons.Question => "\xe6a4",
                MessageViewIcons.Error => "\xe6a1",
                MessageViewIcons.Exclamation => "\xe6d2",
                MessageViewIcons.Hand => "\xe6a7",
                MessageViewIcons.Stop => "\xe6a7",
                MessageViewIcons.Warning => "\xe6a6",
                MessageViewIcons.Successful => "\xe6a2",
                _ => ""
            };

            IconForeground = icon switch
            {
                MessageViewIcons.Asterisk => Brushes.Blue,
                MessageViewIcons.Information => Brushes.Green,
                MessageViewIcons.Question => Brushes.Yellow,
                MessageViewIcons.Error => Brushes.Red,
                MessageViewIcons.Exclamation => Brushes.Yellow,
                MessageViewIcons.Hand => Brushes.Red,
                MessageViewIcons.Stop => Brushes.Red,
                MessageViewIcons.Warning => Brushes.Yellow,
                MessageViewIcons.Successful => Brushes.Green,
                _ => Brushes.Transparent
            };
        }

        [RelayCommand]
        private void Ok()
        {
            Close(DialogResults.Ok);
        }

        [RelayCommand]
        private void Cancel()
        {
            Close(DialogResults.Cancel);
        }

        [RelayCommand]
        private void Yes()
        {
            Close(DialogResults.Yes);
        }

        [RelayCommand]
        private void No()
        {
            Close(DialogResults.No);
        }

        private void Close(DialogResults dialogResult, object? result = null) 
        {
            DialogHost.Close("MessageBox", new MessageBoxResults(dialogResult, result));
        }
    }

    [Flags]
    public enum MessageViewButtons
    {
        Ok = 0,
        Cancel = 1,
        Yes = 2,
        No = 4,
    }

    public enum MessageViewIcons
    {
        None = 0,
        Asterisk = 1,
        Information,
        Question,
        Error,
        Exclamation,
        Hand,
        Stop,
        Warning,
        Successful,
    }

    public enum DialogResults
    {
        Ok = 0,
        Cancel = 1,
        Yes = 2,
        No = 4,
    }

    public class MessageBoxResults
    {
        public DialogResults DialogResult { get; set; }

        public object? Result { get; set; }

        public MessageBoxResults(DialogResults dialogResult, object? result = null) 
        {
            DialogResult = dialogResult;
            Result = result;
        }
    }
}
