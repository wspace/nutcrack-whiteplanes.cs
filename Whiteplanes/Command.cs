using System;

namespace Whiteplanes
{
    /// <summary>
    /// The interface for whitespace command.
    /// </summary>
    internal abstract class Command : IEquatable<Command>
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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool IEquatable<Command>.Equals(Command other)
        {
            return Is(other);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected virtual bool Is(Command other)
        {
            return GetType() == other.GetType();
        }
    }
}
