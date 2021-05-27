using System.Threading.Tasks;

using SIS.MvcFramework;


namespace MyFirstMvcApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp());
        }
    }
}
