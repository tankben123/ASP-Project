namespace WebAppIdentityCore.Models
{
    public class Email
    {
        public string Address { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public bool IsBodyHtml  { get; set; }
    }
}
