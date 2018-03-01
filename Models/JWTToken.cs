namespace IronRebelB2B.Models
{
    public class JWTToken
    {
        public JWTToken()
        {   }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
