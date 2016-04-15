using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Whiteplanes
{
    /// <summary>
    /// 
    /// </summary>
    public class Whiteplanes
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public delegate int InputEventHandler(object sender);

        /// <summary>
        /// 
        /// </summary>
        public class OutputEventArgs
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="code"></param>
            public OutputEventArgs(int code)
            {
                Code = code;
            }

            /// <summary>
            /// 
            /// </summary>
            public int Code { get; private set; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void OutputEventHandler(object sender, OutputEventArgs e);

        /// <summary>
        /// 
        /// </summary>
        private readonly List<Command> _commands;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        public Whiteplanes(Stream stream)
        {
            using (var reader = new StreamReader(stream))
                _commands = new Parser(reader).Parse();
        }

        /// <summary>
        /// 
        /// </summary>
        public InputEventHandler InputEvent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public event OutputEventHandler OutputEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void Run(IContextable context)
        {
            _commands.Where(c => c is Commands.Register).ToList().ForEach(c => c.Process(context));
            Execute(context);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        private void Execute(IContextable context)
        {
            Commands.Output<int>.OutputEvent  += OutputEvent;
            Commands.Output<char>.OutputEvent += OutputEvent;

            foreach (dynamic command in Progress(context).Where(c => c is Commands.Register == false))
            {
                if ((command is Commands.Input<char>) || (command is Commands.Input<int>))
                {
                    command.InputEvent = InputEvent;
                }
                command.Process(context);
            }
            Commands.Output<int>.OutputEvent  -= OutputEvent;
            Commands.Output<char>.OutputEvent -= OutputEvent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private IEnumerable<Command> Progress(IContextable context)
        {
            while (context.ProgramCounter < _commands.Count)
            {
                yield return _commands[context.ProgramCounter];
                context.ProgramCounter += 1;
            }
            
        } 
    }
}
