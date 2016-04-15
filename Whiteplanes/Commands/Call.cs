namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "CALL" Command.
    /// </summary>
    class Call : Command
    {
        /// <summary>
        /// The name of the function to call.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location of the function to call.
        /// </summary>
        public int Location { get; set; }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context)
        {
            context.Callstack.Push(Location);
            context.ProgramCounter = context.Labels[Name];
        }
    }
}
