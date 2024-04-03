using Serilog;

class Program
{
  static async Task Main()
  {
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .WriteTo.File("logs/my-logs.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();

    Log.Information("Meu log!");

    int a = 10, b = 0;
    try
    {
      Log.Debug("Dividindo {A} by {B}", a, b);
      Console.WriteLine(a / b);
    }
    catch (Exception ex)
    {
      Log.Error(ex, "Algo deu errado");
    }
    finally
    {
      await Log.CloseAndFlushAsync();
    }
  }
}
