using System.Linq;

namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "COPY" Command.
    /// </summary>
    class Copy : Command
    {
        /// <summary>
        /// Stack position that you want to copy.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.Stack.Push(context.Stack.ElementAt(Value));

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool Is(Command other)
        {
            if (base.Is(other))
            {
                var command = other as Copy;
                return Value == command.Value;

            }
            return false;
        }
    }
}
