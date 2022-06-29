using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace DeskHubSharpRevised;

public partial class HelpWindow : Window
{
    public HelpWindow()
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
}