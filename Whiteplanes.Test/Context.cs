using System.Collections.Generic;

namespace Whiteplanes.Test
{
    /// <summary>
    /// 
    /// </summary>
    public class Context : IContextable
    {
        /// <summary>
        /// 
        /// </summary>
        public Context()
        {
            Stack = new Stack<int>();
            Heap = new Dictionary<int, int>();
            Labels = new Dictionary<string, int>();
            Callstack = new Stack<int>();
            ProgramCounter = 0;
        }

        /// <summary />
        public Stack<int> Stack { get; }

        /// <summary />
        public Dictionary<int, int> Heap { get; }

        /// <summary />
        public Dictionary<string, int> Labels { get; }

        /// <summary />
        public Stack<int> Callstack { get; }

        /// <summary />
        public int ProgramCounter { get; set; }
    }
}
