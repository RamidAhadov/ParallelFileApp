using Microsoft.Extensions.Configuration;
using ParallelFileApp.Configuration.Paths;

namespace ParallelFileApp.Configuration;

public class Configs
{
    private IConfiguration Configuration { get; }
    private FilePath _filePath;

    public Configs(IConfiguration configuration)
    {
        Configuration = configuration;
        _filePath = Configuration.GetSection("TokenOptions").Get<FilePath>();
    }
}