namespace DeskHubSharpRevised.Models

open System.Collections.ObjectModel

type RequestList() =
    static member val userDetail = new User()
        with get, set
    static member val branchDetail = new ObservableCollection<Branch>()
        with get, set
    static member val repoDetail = new ObservableCollection<RepoDetail>()
        with get, set