using Sandbox.DispatchTable;
using Xunit;

namespace Sandbox.Tests.DispatchTable
{
    public class DispatcherTest
    {
        [Fact]
        public void RunDispatcher()
        {
            var dispatcher = new Dispatcher();
            dispatcher.Run();
        }
    }
}
