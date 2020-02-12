using System.Threading.Tasks;
using SpeedTestApi.Models;

namespace SpeedTestApi
{
    public interface ISpeedTestEvents
    {
        Task PublishSpeedTestEvents(TestResult SpeedTest);
    }
}