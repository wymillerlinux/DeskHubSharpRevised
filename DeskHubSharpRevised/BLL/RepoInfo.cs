using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using DeskHubSharpRevised.Models;

namespace DeskHubSharpRevised.BLL;

class RepoInfo
{
    public RepoInfo()
    {

    }

    /// <summary>
    /// Returns a list for the list box
    /// </summary>
    /// <returns>A list of strings</returns>
    public List<string> GetRepoInfoList()
    {
        List<string> stuff = new List<string>();

        try
        {
            stuff = RequestList.repoDetail.Select(r => r.full_name).ToList();
        }
        catch (Exception)
        {
            ErrorWindow err = new ErrorWindow();
            err.txtblk_error = err.Find<TextBlock>("txtblk_error");
            err.txtblk_error.Text = "Did you search a user? Try that first.";
            err.btn_error_close = err.Find<Button>("btn_error");
            err.btn_error_close.Content = "Close";
            err.lbl_title = err.Find<Label>("lbl_title");
            err.lbl_title.Content = "Oops!";
            err.Show();
        }

        return stuff;
    }

    /// <summary>
    /// Returns a list for the combo box
    /// </summary>
    /// <returns>A list of strings</returns>
    public List<string> GetBranchNameComboBox()
    {
        List<string> stuff = RequestList.branchDetail.Select(b => b.name).ToList();
        return stuff;
    }
}