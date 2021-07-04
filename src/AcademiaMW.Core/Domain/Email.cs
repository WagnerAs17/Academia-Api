namespace AcademiaMW.Core.Domain
{
    public class Email
    {
        public string Subject { get; private set; }
        public string To { get; private set; }
        public string Message { get; private set; }

        public Email(string subject, string to, string message)
        {
            Subject = subject;
            To = to;
            Message = message;
        }
    }
}
