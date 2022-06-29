using System;
using System.Collections.Generic;
using System.Linq;
using DeskHubSharpRevised.Models;

namespace DeskHubSharpRevised.BLL;

class RepoInfo
{
    public RepoInfo()
    {

    }

    /// <summary>
    /// Return a list for the list box
    /// </summary>
    /// <returns></returns>
    public List<string> GetRepoInfoList()
    {
        List<string> stuff = new List<string>();

        try
        {
            stuff = RequestList.repoDetail.Select(x => x.full_name).ToList();
        }
        catch (Exception)
        {
            ErrorWindow err = new ErrorWindow();
            err.txtblk_error.Text = "We couldn't gather any data. Does the user exist?";
            err.btn_error_close.Content = "FUCK!";
            err.lbl_title.Content = "Oops!";
            err.Show();
        }

        return stuff;
    }

    /// <summary>
    /// Return a list for the combo box
    /// </summary>
    /// <returns></returns>
    public List<string> GetBranchNameComboBox()
    {
        List<string> stuff = RequestList.branchDetail.Select(x => x.name).ToList();
        return stuff;
    }
}