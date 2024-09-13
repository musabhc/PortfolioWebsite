namespace PortfolioWebsite.DAL.Entities
{
    public class Message
    {
        public int messageId { get; set; }
        public string nameSurname { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public string messageDetail { get; set; }
        public DateTime sendDate { get; set; }
        public bool isRead { get; set; }
    }
}
