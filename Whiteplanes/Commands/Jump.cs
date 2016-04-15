namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "JUMP" Command.
    /// </summary>
    class Jump : Command
    {
        /// <summary>
        /// The name of the jump location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.ProgramCounter = context.Labels[Name];
    }
}
