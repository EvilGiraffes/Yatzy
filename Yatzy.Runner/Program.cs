using Serilog;
using Serilog.Core;

using Yatzy.Runner;

#if DEBUG
string configType = "Development";
#else
string configType = "Production";
#endif
string filename = PathHandler.GetFileName(configType);
string configPath = PathHandler.GetConfigPath(filename);

using (Logger logger = new LoggerConfiguration()
        .ReadFrom.AppSettings(filePath: configPath)
        .Enrich.FromLogContext()
        .CreateLogger())
{
    Console.ReadKey();
}
