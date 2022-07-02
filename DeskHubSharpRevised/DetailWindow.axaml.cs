using System.Collections;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DeskHubSharpRevised.BLL;
using DeskHubSharpRevised.Models;

namespace DeskHubSharpRevised;

public partial class DetailWindow : Window
{
    // Private members
    private readonly RepoDetail _repoDetail;
    private readonly ComboBox? _cmbbox_branches_items;
    private TextBlock? _txtblk_language_text;
    private Label? _lbl_reponame_content;
    private TextBlock? _txtblk_watchers_text;
    private TextBlock? _txtblk_stargazers_text;
    private TextBlock? _txtblk_forks_text;
    private Request _request;
    private Owner _owner;
    
    public DetailWindow()
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

    public DetailWindow(RepoDetail repoDetail)
    {
        InitializeComponent();

        _repoDetail = repoDetail;
        _request = new Request(_repoDetail.name);
        _owner = new Owner();
        _cmbbox_branches_items = this.Find<ComboBox>("cmbbox_branches");
        _txtblk_language_text = this.Find<TextBlock>("txtblk_language");
        _txtblk_watchers_text = this.Find<TextBlock>("txtblk_watchers");
        _txtblk_stargazers_text = this.Find<TextBlock>("txtblk_stargazers");
        _txtblk_forks_text = this.Find<TextBlock>("txtblk_forks");
        _lbl_reponame_content = this.Find<Label>("lbl_reponame");
        RepoInfo info = new RepoInfo();

        _request.PerformBranchRequest();
        var stuff = info.GetBranchNameComboBox();
        
        _cmbbox_branches_items.Items = stuff;

        if (_repoDetail.language != null)
        {
            _txtblk_language_text.Text = $"This repo is mostly {_repoDetail.language} code.";
        }
        else
        {
            _txtblk_language_text.Text = "This repo doesn't have any code.";
        }

        _lbl_reponame_content.Content = _repoDetail.full_name;
        _txtblk_stargazers_text.Text = $"This repo has {_repoDetail.stargazers_count} stargazers.";
        _txtblk_watchers_text.Text = $"This repo has {_repoDetail.watchers_count} watchers.";
        _txtblk_forks_text.Text = $"This repo has {_repoDetail.forks_count} forks.";
    }

    private void btn_close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btn_clone_Click(object sender, RoutedEventArgs e)
    {
        if (cmbbox_branches.SelectedItem.ToString() == "")
        {
            ErrorWindow err = new ErrorWindow();
            err.txtblk_error.Text = "Please select a branch to clone.";
            err.Show();
        }
        else
        {
            _owner = new Owner();
            string link = "https://github.com/" + _owner.login + "/" + _repoDetail.name + "/archive/" + cmbbox_branches.SelectedItem + ".zip";

            Process.Start(link);
        }

    }

    private void btn_page_Click(object sender, RoutedEventArgs e)
    {
        Process.Start($"{_repoDetail.html_url}");
    }
}