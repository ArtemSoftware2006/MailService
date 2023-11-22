namespace service.Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public string EmailFrom{ get; set; }
        public string EmailTo { get; set; }
    }
}