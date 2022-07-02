namespace DeskHubSharpRevised.Models

type public Sort() =
    let terms =
        ["A - Z"; "Least to Most Stars"; "Least to Most Forks"; "Least to Most Watchers"]
        
    member this.GetSortTerms = ResizeArray<string> terms