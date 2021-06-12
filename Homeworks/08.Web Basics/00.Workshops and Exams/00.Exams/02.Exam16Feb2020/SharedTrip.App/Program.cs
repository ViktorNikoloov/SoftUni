using System.Threading.Tasks;

using SIS.MvcFramework;

namespace SharedTrip.App
{
    public class Program
    {
        static async Task Main()
        {
            await Host.CreateHostAsync(new StartUp());
        }
    }
}
