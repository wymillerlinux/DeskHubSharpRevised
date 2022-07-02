namespace DeskHubSharpRevised.Models

type RepoDetail() =
    member val owner: Owner = new Owner()
        with get, set
    member val license: License = new License()
        with get, set
    member val id: int = 0
        with get, set
    member val node_id: string = null
        with get, set
    member val name: string = null
        with get, set
    member val full_name: string = null
        with get, set
    member val html_url: string = null
        with get, set
    member val description: string = null
        with get, set
    member val stargazers_count: int = 0
        with get, set
    member val forks_count: int = 0
        with get, set
    member val watchers_count: int = 0
        with get, set
    member val language: string = null
        with get, set