namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "RETURN" Command.
    /// </summary>
    class Return : Command
    {
        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.ProgramCounter = context.Callstack.Pop();
    }
}
