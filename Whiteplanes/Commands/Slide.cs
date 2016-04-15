namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "SLIDE" Command.
    /// </summary>
    class Slide : Command
    {
        /// <summary>
        /// The value to be removed from the stack
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context)
        {
            var slideValue = context.Stack.Pop();
            for (var index = 0; index < Value; ++index)
            {
                context.Stack.Pop();
            }
            context.Stack.Push(slideValue);
        }
    }
}
