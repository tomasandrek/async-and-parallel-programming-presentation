using System.Threading.Tasks;

namespace ClientDemonstration
{
    public interface IDemonstrable
    {
        void Demonstrate();
        Task DemonstrateAsync();
    }
}