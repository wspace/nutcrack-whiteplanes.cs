namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "STORE" Command.
    /// </summary>
    class Store : Command
    {
        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context)
        {
            var value = context.Stack.Pop();
            var address = context.Stack.Pop();
            context.Heap[address] = value;
        }
    }
}
