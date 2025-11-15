using System.IO;
using CSnakes.Runtime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace fishing_tool.Core.Python
{
    public class PythonService:ISingleton
    {
        private readonly IHost app;
        private readonly IPythonEnvironment environment;
        //private readonly string path  = Environment.CurrentDirectory;
        public PythonService() {

            var builder = Host.CreateDefaultBuilder()
                    .ConfigureServices(services =>
                    {
                        var home = Path.Join(Environment.CurrentDirectory, "/Core/Python"); // path to python modyle
                        services
                            .WithPython()
                            .WithHome(home)
                            .FromRedistributable(); // Download Python
                            



                    });

           app = builder.Build();
           environment = app.Services.GetRequiredService<IPythonEnvironment>();


        }


        public bool exec_script(string path)
        {

            var module = environment.Script();
            try
            {
                var result = module.Generate(path);
            }
            catch (PythonInvocationException ex)
            {
                Console.WriteLine($"Python error: {ex.Message}");
                return false;
            }
            return true;


        }

        public bool GetPath()
        {
            return true;
        }
    }
}
