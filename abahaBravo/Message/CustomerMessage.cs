namespace abahaBravo.Message
{
    public class CustomerMessage
    {
        public CustomerMessage(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}