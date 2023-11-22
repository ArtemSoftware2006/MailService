namespace service.Domain
{
    public class SendMessageRequest
    {
        public string Body { get; set; }
        public string Author { get; set; }
        public string EmailTo { get; set; }
    }
}