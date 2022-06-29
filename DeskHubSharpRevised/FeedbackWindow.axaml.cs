using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DeskHubSharpRevised.BLL;

namespace DeskHubSharpRevised;

public partial class FeedbackWindow : Window
{
    public FeedbackWindow()
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
    
    private void btn_discard_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btn_send_Click(object sender, RoutedEventArgs e)
    {
        EmailBLL email = new EmailBLL(txtbox_name.Text, txtbox_feedbackmessage.Text, txtbox_email.Text);
        email.CreateMessage();
    }
}