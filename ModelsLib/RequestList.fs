namespace DeskHubSharpRevised.Models

open System.Collections.ObjectModel

type RequestList =
    static member userDetail
        with get(): obj = null
        and set(value) = RequestList.userDetail <- value
    static member branchDetail
        with get(): ObservableCollection<Branch> = null
        and set(value: ObservableCollection<Branch>) = RequestList.branchDetail <- value
    static member repoDetail
        with get(): ObservableCollection<RepoDetail> = null
        and set(value: ObservableCollection<RepoDetail>) = RequestList.repoDetail <- value