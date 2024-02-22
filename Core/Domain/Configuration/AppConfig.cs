namespace Core.Domain.Configuration;

public class AppConfig
{
    public ConnectionString ConnectionStrings { get; set; }
}

public class ConnectionString
{
    public string Sqlite { get; set; }
}