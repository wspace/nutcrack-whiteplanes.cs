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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool Is(Command other)
        {
            if (base.Is(other))
            {
                var command = other as Slide;
                return Value == command.Value;

            }
            return false;
        }
    }
}
