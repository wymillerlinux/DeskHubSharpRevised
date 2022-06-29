using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace DeskHubSharpRevised;

public partial class ErrorWindow : Window
{
    public ErrorWindow()
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
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}