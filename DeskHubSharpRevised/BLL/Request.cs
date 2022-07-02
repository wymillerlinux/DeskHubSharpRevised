using System.Collections.Generic;
using System.Linq;
using DeskHubSharpRevised.DAL;
using DeskHubSharpRevised.Models;

namespace DeskHubSharpRevised.BLL;

public class Request
{
    private readonly ApiDataService _api;
    private readonly string _query;

    /// <summary>
    /// Override constructor for the class
    /// </summary>
    /// <param name="query"></param>
    public Request(string query)
    {
        _query = query;
        _api = new ApiDataService(_query);
    }

    /// <summary>
    /// Constructor for the class
    /// </summary>
    public Request()
    {

    }

    /// <summary>
    /// Performs the search request 
    /// </summary>
    public void PerformSearchRequest()
    {
        _api.SearchRequest();
    }

    /// <summary>
    /// Performs the user request
    /// </summary>
    public void PerformUserRequest()
    {
        _api.UserRequest();
    }

    /// <summary>
    /// Performs the branch request
    /// </summary>
    public void PerformBranchRequest()
    {
        _api.BranchRequest();
    }

    /// <summary>
    /// Performs the local owner request
    /// </summary>
    /// <returns></returns>
    public Owner GetUserData()
    {
        Owner owner = new Owner();
        return owner;
    }

    public List<string> PerformGetSort()
    {
        return new Sort().GetSortTerms;
    }
}