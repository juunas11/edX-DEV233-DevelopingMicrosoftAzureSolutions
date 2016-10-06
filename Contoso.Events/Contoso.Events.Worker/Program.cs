using Microsoft.Azure.WebJobs;

namespace Contoso.Events.Worker
{
    class Program
    {
        static void Main()
        {
            new JobHost().RunAndBlock();
        }
    }
}
