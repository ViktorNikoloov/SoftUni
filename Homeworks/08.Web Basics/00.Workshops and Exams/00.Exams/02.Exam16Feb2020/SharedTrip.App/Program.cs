using SIS.MvcFramework;
using System.Threading.Tasks;


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
