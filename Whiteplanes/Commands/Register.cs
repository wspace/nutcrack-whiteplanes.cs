namespace Whiteplanes.Commands
{
    /// <summary>
    /// The "REGISTER" Command.
    /// </summary>
    internal class Register : Command
    {
        /// <summary>
        /// The name of the function to register.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Location of the function to register.
        /// </summary>
        public int Location { get; set; }

        /// <summary>
        /// Run the command.
        /// </summary>
        /// <param name="context">Execution context.</param>
        public override void Process(IContextable context) => context.Labels.Add(Name, Location);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        protected override bool Is(Command other)
        {
            if (base.Is(other))
            {
                var command = other as Register;
                return (Name == command.Name) && (Location == command.Location);

            }
            return false;
        }
    }
}
