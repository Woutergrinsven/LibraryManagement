namespace Bibliotheek
{
    public class JwtBearerConfig
    {
        public static string CLAIM_ID_NAME = "id";
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
