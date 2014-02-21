using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Internal
{
    public sealed class TestData
    {
        public TestData(IEnumerable<SingleCommand> commands)
        {
            Commands = commands.ToList().AsReadOnly();
        }

        public IReadOnlyList<SingleCommand> Commands
        {
            get;
            private set;
        }
    }
}
