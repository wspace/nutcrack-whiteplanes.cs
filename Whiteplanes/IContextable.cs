using System.Collections.Generic;

namespace Whiteplanes
{
    /// <summary>
    /// The interface of execution context for whitespace.
    /// </summary>
    public interface IContextable
    {
        /// <summary />
        Stack<int> Stack { get; }

        /// <summary />
        Dictionary<int, int> Heap { get; }

        /// <summary />
        Dictionary<string, int> Labels { get; }

        /// <summary />
        Stack<int> Callstack { get; }

        /// <summary />
        int ProgramCounter { get; set; }
    }
}
