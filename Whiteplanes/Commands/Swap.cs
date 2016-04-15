namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "SWAP" Command.
    /// </summary>
    class Swap : Command
    {
        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context)
        {
            var lhs = context.Stack.Pop();
            var rhs = context.Stack.Pop();
            context.Stack.Push(lhs);
            context.Stack.Push(rhs);
        }
    }
}
