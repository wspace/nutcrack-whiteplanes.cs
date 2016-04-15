namespace Whiteplanes
{
    /// <summary>
    /// 
    /// </summary>
    class SyntaxException : WhiteplanesException
    {
        /// <summary>
        /// 
        /// </summary>
        public override string Message { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public SyntaxException(string message)
        {
            Message = message;
        }
    }
}
