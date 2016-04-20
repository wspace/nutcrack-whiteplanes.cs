using System;

namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "TEST" Command.
    /// </summary>
    internal class Test : Command
    {
        /// <summary>
        /// The name of the jump location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Function to be used for comparison.
        /// </summary>
        public Func<int, bool?> Compare { get; set; }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context)
        {
            var value = context.Stack.Pop();
            var comparation = Compare(value);
            if (comparation.HasValue && comparation.Value)
            {
                context.ProgramCounter = context.Labels[Name];
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool Is(Command other)
        {
            if (base.Is(other))
            {
                var command = other as Test;
                return (Name == command.Name) && (Compare == command.Compare);
            }
            return false;
        }
    }
}
