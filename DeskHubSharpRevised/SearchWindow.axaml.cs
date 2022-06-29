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
    private Request _request;
    private ObservableCollection<RepoDetail> _repoDetail;
    
    public SearchWindow()
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

    private void btn_search_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(txtbox_query.Text))
        {
            var parentWindow = this;
            ErrorWindow err = new ErrorWindow();
            err.txtblk_error.Text = "Please enter a username!";
            err.ShowDialog(parentWindow);
        }
        else
        {
            _request = new Request(txtbox_query.Text);
            _request.PerformSearchRequest();
            _request.PerformUserRequest();
            this.Close();
        }
        
    }
}