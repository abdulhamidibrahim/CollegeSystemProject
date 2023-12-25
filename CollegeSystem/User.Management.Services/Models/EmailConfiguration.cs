namespace User.Management.Services.Models;

// To get data from appsettings.json

public class EmailConfiguration
{
    public string From { get; set; } = string.Empty;
    public string SmtpServer { get; set; } = null!;
    public int Port { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}