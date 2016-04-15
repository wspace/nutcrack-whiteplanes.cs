namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "DISCARD" Command.
    /// </summary>
    class Discard : Command
    {
        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.Stack.Pop();
    }
}
