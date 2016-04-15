namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "END" Command.
    /// </summary>
    class End : Command
    {
        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.ProgramCounter = int.MaxValue - 1;
    }
}
