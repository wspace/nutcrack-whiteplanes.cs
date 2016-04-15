using System;

namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "INPUT" Command.
    /// </summary>
    class Input<T> : Command
    {
        /// <summary>
        /// Sets delegate method to use when it is called Input#Process.
        /// </summary>
        public Whiteplanes.InputEventHandler InputEvent { get; set; }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context)
        {

            Type[] genericArgs = this.GetType().GetGenericArguments();
            var address = context.Stack.Pop();
            if (genericArgs[0].Name.Equals("Char"))
            {
                context.Heap[address] = (char)InputEvent(this);
            }
            else
            {
                context.Heap[address] = InputEvent(this);
            }
        }
    }
}
