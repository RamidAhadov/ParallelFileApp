using Microsoft.Extensions.Configuration;
using ParallelFileApp.Configuration.ConfigParameters;

namespace ParallelFileApp.Configuration;

public class Configs:IConfigs
{
    private IConfiguration Configuration { get; }
    private FilePath _filePath;
    private FileText _fileText;

    public Configs(IConfiguration configuration)
    {
        Configuration = configuration;
        _fileText = Configuration.GetSection("FileText").Get<FileText>();;
        _filePath = Configuration.GetSection("PathConfiguration").Get<FilePath>();
    }

    public string Path()
    {
        return _filePath.CreationPath;
    }

    public string Text()
    {
        return _fileText.Text;
    }
}

public interface IConfigs
{
    string Path();
    string Text();
}