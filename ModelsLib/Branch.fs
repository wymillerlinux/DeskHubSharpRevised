namespace DeskHubSharpRevised.Models

type Branch() =
        member val name: string = null
            with get, set
    
        member val commit = new Commit()
            with get, set