namespace RoBHo_UserService.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int Iterations { get; set; }
        public string ConnectionString { get; set; }
        public string AllowedHosts { get; set; }
    }
}