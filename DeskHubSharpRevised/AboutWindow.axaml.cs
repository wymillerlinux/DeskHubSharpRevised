using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace DeskHubSharpRevised;

public partial class AboutWindow : Window
{
    public AboutWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void btn_close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void OnOpened(object sender, EventArgs e)
    {
        base.OnOpened(e);
    }
}