namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "DIV" Command.
    /// </summary>
    class Division : Command
    {
        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.Stack.Push(context.Stack.Pop() / context.Stack.Pop());
    }
}
