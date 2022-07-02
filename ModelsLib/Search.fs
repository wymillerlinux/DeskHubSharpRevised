namespace DeskHubSharpRevised.Models

open System.Collections.Generic

type Search() =
    member this.total_count with get(): int = 0
    member this.incomplete_results with get(): int = 0
    member this.items with get(): List<obj> = null
    
    type SearchOwner() =
        member this.login
            with get(): string = null
            and set(value: string) = this.login <- value
        member this.id
            with get(): int = 0
            and set(value: int) = this.id <- value
        member this.node_id
            with get(): string = null
        member this.avatar_url
            with get(): string = null
        member this.gravatar_url
            with get(): string = null
        member this.url
            with get(): string = null
        member this.received_events_url
            with get(): string = null
        member this.types
            with get(): string = null
        
    type ItemsItem() =
        member this.id with get(): int = 0
        member this.node_id with get(): string = null
        member this.name with get(): string = null
        member this.full_name with get(): string = null
        member this.owner with get(): obj = null
        member this.privates with get(): string = null
        member this.url with get(): string = null
        member this.created_at with get(): string = null
        member this.updated_at with get(): string = null
        member this.pushed_at: string = null
        member this.homepage: string = null
        member this.size: int = 0
        member this.stargazers_count: int = 0
        member this.watchers_count: int = 0
        member this.language: string = null
        member this.forks_count: string = null
        member this.open_issues_count: int = 0
        member this.master_branch: string = null
        member this.default_branch: string = null
        member this.score: double = 0.0
        
        