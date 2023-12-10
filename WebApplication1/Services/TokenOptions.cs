namespace BookStore.Services
{
    public class TokenOptions
    {
        public string Secret { get; set; }
        public int ExpiresDay { get; set; }
    }
}
