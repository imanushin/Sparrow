using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Internal
{
    public sealed class SingleCommand
    {
        public SingleCommand(string commandText, IReadOnlyList<string> arguments)
        {
            CommandText = commandText;
            Arguments = arguments;
        }

        public string CommandText
        {
            get;
            private set;
        }

        public IReadOnlyList<string> Arguments
        {
            get;
            private set;
        } 
    }
}
