namespace abahaBravo.Util
{
    public class BodyRequest
    {
        public static string GetbodyAuth(string id, string secret)
        {
            return "scopes=PublicApi.Access&grant_type=client_credentials&client_id=" + id + "&client_secret=" + secret;
        }
    }
}