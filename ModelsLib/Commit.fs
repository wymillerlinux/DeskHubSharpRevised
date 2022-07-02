namespace DeskHubSharpRevised.Models

type Commit() =
    member this.sha with get(): string = null
    member this.url with get(): string = null