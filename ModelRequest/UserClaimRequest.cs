namespace ProductAPI.ModelRequest
{
    public class UserClaimRequest
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string Username { get; set; }

    }
}
