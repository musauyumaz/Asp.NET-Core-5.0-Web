namespace ConfigurationExample.Models
{
    public class MailInfo
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public EmailInfo EmailInfo { get; set; }
    }
    public class EmailInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
