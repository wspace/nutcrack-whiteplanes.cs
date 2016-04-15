namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "DUPLICATE" Command.
    /// </summary>
    class Duplicate : Command
    {
        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.Stack.Push(context.Stack.Peek());
    }
}
