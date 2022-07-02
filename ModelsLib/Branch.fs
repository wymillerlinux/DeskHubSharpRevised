namespace DeskHubSharpRevised.Models

type Branch() =
    member this.name: string = null
    member this.commit with get(): obj = null
    
    type Commit() =
        member this.sha with get(): string = null
        member this.url with get(): string = null