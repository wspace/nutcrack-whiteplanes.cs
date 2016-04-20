namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "PUSH" Command.
    /// </summary>
    class Push : Command
    {
        /// <summary>
        /// Value to be pushed onto the stack.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.Stack.Push(Value);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool Is(Command other)
        {
            if (base.Is(other))
            {
                var command = other as Push;
                return Value == command.Value;

            }
            return false;
        }
    }
}
