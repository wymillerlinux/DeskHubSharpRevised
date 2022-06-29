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
    public DetailWindow()
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
    
    private RepoDetail _repoDetail;
    private Request _request;
    private Owner _owner;

    public DetailWindow(RepoDetail repoDetail)
    {
        InitializeComponent();

        _repoDetail = repoDetail;
        _request = new Request(_repoDetail.name);
        RepoInfo info = new RepoInfo();

        _request.PerformBranchRequest();
        var stuff = info.GetBranchNameComboBox();

        cmbbox_branches.Items= stuff;

        if (_repoDetail.language != null)
        {
            txtblk_language.Text = $"This repo is mostly {_repoDetail.language} code.";
        }
        else
        {
            txtblk_language.Text = "This repo doesn't have any code.";
        }

        lbl_reponame.Content = _repoDetail.full_name;
        txtblk_stargazers.Text = $"This repo has {_repoDetail.stargazers_count} stargazers.";
        txtblk_watchers.Text = $"This repo has {_repoDetail.watchers_count} watchers.";
        txtblk_forks.Text = $"This repo has {_repoDetail.forks_count} forks.";
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
            string link = "https://github.com/" + _repoDetail.owner.login + "/" + _repoDetail.name + "/archive/" + cmbbox_branches.SelectedItem + ".zip";

            Process.Start(link);
        }

    }

    private void btn_page_Click(object sender, RoutedEventArgs e)
    {
        Process.Start($"{_repoDetail.html_url}");
    }
}