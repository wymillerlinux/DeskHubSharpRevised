using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using DeskHubSharpRevised.BLL;
using DeskHubSharpRevised.Models;

namespace DeskHubSharpRevised
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<RepoDetail> _repoDetail;
        private User _user;
        private Request _request;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void btn_detail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RepoDetail repo = _repoDetail[ListBox.SelectedIndex];
                DetailWindow detail = new DetailWindow(repo);
                detail.Show();
            }
            catch (IndexOutOfRangeException)
            {
                ShowErrorMessage("Please pick a repository!");
            }
            catch (NullReferenceException)
            {
                ShowErrorMessage("Please search for a user with the Search button!");
            }
            catch (ArgumentOutOfRangeException)
            {
                ShowErrorMessage("Please search for a user with the Search button!");
            }

        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void btn_about_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.Show();
        }

        private void btn_feedback_Click(object sender, RoutedEventArgs e)
        {
            FeedbackWindow feedback = new FeedbackWindow();
            feedback.Show();
        }

        private void btn_help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.Show();
        }

        private async void btn_search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow search = new SearchWindow();
            await search.ShowDialog(this);
            _repoDetail = RequestList.repoDetail;
            RepoInfo info = new RepoInfo();
            var stuff = info.GetRepoInfoList();

            if (stuff == null)
            {
                txtblk_username.Text = txtblk_username.Text;
                txtblk_url.Text = txtblk_url.Text;
                txtblk_bio.Text = txtblk_bio.Text;
                txtblk_email.Text = txtblk_email.Text;
                txtblk_realname.Text = txtblk_realname.Text;
            }
            else
            {
                _user = RequestList.userDetail;
                ListBox.Items = stuff;
                txtblk_username.Text = _user.login;
                txtblk_url.Text = _user.html_url;
                txtblk_bio.Text = _user.bio;
                txtblk_email.Text = _user.blog;
                txtblk_realname.Text = _user.name;
                txtblk_repocount.Text = $"{_user.login} has {_user.public_repos} public repositories.";
            }
        }

        public void ShowErrorMessage(string message)
        {
            ErrorWindow err = new ErrorWindow();
            try
            {
                err.lbl_title.Content = "Oops!";
                err.txtblk_error.Text = message;
            }
            catch (NullReferenceException e)
            {
                err.lbl_title.Content = "Oops!";
                err.txtblk_error.Text = message;
            }

            err.Show();
        }

        private void btn_sort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sortTerm = cmbbox_sort.SelectedItem.ToString();

                if (sortTerm == "A - Z")
                {
                    var sortedList = _repoDetail.OrderBy(x => x.full_name).ToList();
                    ListBox.Items = sortedList.Select(x => x.full_name);
                }
                if (sortTerm == "Least to most Stars")
                {
                    var sortedList = _repoDetail.OrderBy(c => c.stargazers_count).ToList();
                    ListBox.Items = sortedList.Select(x => x.full_name);
                    
                }
                if (sortTerm == "Least to most Forks")
                {
                    var sortedList = _repoDetail.OrderBy(c => c.forks_count).ToList();
                    ListBox.Items = sortedList.Select(x => x.full_name);
                }
                if (sortTerm == "Least to most Watchers")
                {
                    var sortedList = _repoDetail.OrderBy(c => c.watchers_count).ToList();
                    ListBox.Items = sortedList.Select(x => x.full_name);
                }
            }
            catch (NullReferenceException)
            {
                ShowErrorMessage("A user has not been searched. Please try again.");
            }
        }

        private void btn_searchrepo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = txtbox_searchbox.Text;
                var searchedList = _repoDetail.Where(c => c.full_name.ToUpper().Contains(searchTerm.ToUpper())).ToList();

                ListBox.Items = searchedList.Select(x => x.full_name);
            }
            catch (ArgumentNullException)
            {
                ShowErrorMessage("A user has not been searched. Please try again.");
            }

        }
    }
}