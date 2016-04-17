namespace Whiteplanes
{
    /// <summary>
    /// The interface for whitespace command.
    /// </summary>
    internal abstract class Command
    {
        public enum InstructionModificationParameter
        {
            StackManipulation,
            Arithmetic,
            HeapAccess,
            FlowControl,
            Interactive,
        }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public abstract void Process(IContextable context);
    }
}
