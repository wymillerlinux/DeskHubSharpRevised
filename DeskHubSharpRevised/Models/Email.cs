namespace DeskHubSharpRevised.Models;

public class Email
{
    private string _toEmail = "wjmiller2016@gmail.com";
    private string _fromEmail = "wjmiller2016@gmail.com";
    private string _passwordEmail = "password";

    public string Password
    {
        get { return _passwordEmail; }
        set { _passwordEmail = value; }
    }

    public string FromEmail
    {
        get { return _fromEmail; }
        set { _fromEmail = value; }
    }

    public string ToEmail
    {
        get { return _toEmail; }
        set { _toEmail = value; }
    }

    /// <summary>
    /// Constructor for the Email class
    /// </summary>
    public Email()
    {

    }
}