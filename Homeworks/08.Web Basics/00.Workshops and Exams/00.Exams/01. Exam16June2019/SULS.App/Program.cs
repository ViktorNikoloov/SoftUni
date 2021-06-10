using System.Threading.Tasks;

using SIS.MvcFramework;

namespace SULS.App
{
    public class Program
    {
       public  static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp());
        }
    } 
}
