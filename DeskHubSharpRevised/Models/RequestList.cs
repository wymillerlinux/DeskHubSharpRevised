using System.Collections.ObjectModel;

namespace DeskHubSharpRevised.Models;

public class RequestList
{
    /// <summary>
    /// Stores everything in User, typically from the request
    /// </summary>
    public static User userDetail { get; set; }

    /// <summary>
    /// Stores everything sent in Branch, typically from request
    /// </summary>
    public static ObservableCollection<Branch> branchDetail { get; set; }

    /// <summary>
    /// Stores everything sent in RepoDetail, typically from request
    /// </summary>
    public static ObservableCollection<RepoDetail> repoDetail { get; set; }
}