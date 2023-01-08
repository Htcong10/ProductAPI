namespace ProductAPI.ModelRequest
{
    public class RoleClaimRequest
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string RoleName { get; set; }
    }
}
