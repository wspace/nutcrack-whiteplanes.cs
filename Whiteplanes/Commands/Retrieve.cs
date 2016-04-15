namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "RETRIEVE" Command.
    /// </summary>
    class Retrieve : Command
    {
        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context)
        {
            var address = context.Stack.Pop();
            context.Stack.Push(context.Heap[address]);
        }
    }
}
