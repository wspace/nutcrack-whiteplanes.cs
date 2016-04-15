namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "OUTPUT" Command.
    /// </summary>
    class Output<T> : Command
    {
        /// <summary>
        /// Sets delegate method to use when it is called Ouput#Process.
        /// </summary>
        public static event Whiteplanes.OutputEventHandler OutputEvent;

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context)
        {
            int value = context.Stack.Pop();

            if (OutputEvent != null)
            {
                OutputEvent(this, new Whiteplanes.OutputEventArgs(value));
            }
        }
    }
}
