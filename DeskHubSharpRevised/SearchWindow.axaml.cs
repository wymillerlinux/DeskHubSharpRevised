using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DeskHubSharpRevised.BLL;
using DeskHubSharpRevised.Models;

namespace DeskHubSharpRevised;

public partial class SearchWindow : Window
{
    public string userResponse { get; set; }
    private Request _request;
    private ObservableCollection<RepoDetail> _repoDetail;

    public SearchWindow()
    {
        InitializeComponent();
        DataContext = this;
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

    private void btn_search_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(userResponse))
        {
            var parentWindow = this;
            ErrorWindow err = new ErrorWindow();
            err.txtblk_error.Text = "Please enter a username!";
            err.ShowDialog(parentWindow);
        }
        else
        {
            _request = new Request(userResponse);
            _request.PerformSearchRequest();
            _request.PerformUserRequest();
            this.Close();
        }
        
    }
}