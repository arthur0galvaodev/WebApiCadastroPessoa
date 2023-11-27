namespace CadastroPessoa.Persistence
{
    public class Connection
    {
        public IConfiguration Configuration { get; }
        public Connection()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            Configuration = builder.Build();
        }
        public Connection(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string PricipalConnectionString
        {
            get
            {
                string conn = Configuration.GetConnectionString("ConnPrincipal") ?? "";
                return conn;
            }
        }
    }
}
