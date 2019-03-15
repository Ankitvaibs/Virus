using System.Threading.Tasks;

namespace StressTestSimulator.ViewModels
{
    public interface IAsyncCommand
    {
        Task ExecuteAsync();
    }
}