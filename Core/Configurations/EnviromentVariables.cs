namespace Core.Configurations
{
    public static class EnviromentVariables
    {
        public static string DarkXmeraSecurityDbConnectionString { get; } = "DARK-XMERA-SECURITY-DB";

        public static string JwtValidIssuer { get; } = "DARK-XMERA-SECURITY-VALID-ISSUER";

        public static string JwtValidAudience { get; } = "DARK-XMERA-SECURITY-VALID-AUDIENCE";

        public static string JwtSecretKey { get; } = "DARK-XMERA-SECURITY-JWT-SECRET-KEY";
    }
}
