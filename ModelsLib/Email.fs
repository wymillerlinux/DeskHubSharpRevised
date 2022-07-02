namespace DeskHubSharpRevised.Models

type Email() =
    let mutable _toEmail: string = "wjmiller2016@gmail.com"
    let mutable _fromEmail: string = "wjmiller2016@gmail.com"
    let mutable _password: string = "password"
    
    member this.ToEmail
        with get() = _toEmail
        and set(value: string) = _toEmail <- value
    member this.FromEmail
        with get() = _fromEmail
        and set(value: string) = _fromEmail <- value
    member this.Password
        with get() = _password
        and set(value: string) = _password <- value