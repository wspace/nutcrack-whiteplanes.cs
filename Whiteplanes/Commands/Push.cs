namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "PUSH" Command.
    /// </summary>
    class Push : Command
    {
        /// <summary>
        /// Value to be pushed onto the stack.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.Stack.Push(Value);
    }
}
