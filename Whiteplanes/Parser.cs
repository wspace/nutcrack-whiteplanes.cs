using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Whiteplanes.Commands;

namespace Whiteplanes
{
    internal class Parser
    {
        /// <summary>
        /// 
        /// </summary>
        public static class Symbol
        {
            /// <summary />
            public const char Space = ' ';

            /// <summary />
            public const char Tab = '\t';

            /// <summary />
            public const char Newline = '\n';

            /// <summary>
            /// 
            /// </summary>
            /// <param name="character"></param>
            /// <returns></returns>
            public static bool Is(char character)
            {
                return (character == Space) || (character == Tab) || (character == Newline);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly StreamReader _reader;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Parser(StreamReader reader)
        {
            _reader = reader;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Command> Parse()
        {
            var command = new List<Command>();
            foreach (var instruction in GetInstruction())
            {
                switch (instruction)
                {
                    case Command.InstructionModificationParameter.StackManipulation:
                        PushStackManipulationCommand(command);
                        break;
                    case Command.InstructionModificationParameter.Arithmetic:
                        PushArithmeticCommand(command);
                        break;
                    case Command.InstructionModificationParameter.HeapAccess:
                        PushHeapAccessCommand(command);
                        break;
                    case Command.InstructionModificationParameter.FlowControl:
                        PushFlowControlCommand(command);
                        break;
                    case Command.InstructionModificationParameter.Interactive:
                        PushInteractiveCommand(command);
                        break;
                }
            }
            return command;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Command.InstructionModificationParameter> GetInstruction()
        {
            while (MoveToNextToken())
            {
                var character = (char) _reader.Read();
                switch (character)
                {
                    case Symbol.Space:
                        yield return Command.InstructionModificationParameter.StackManipulation;
                        break;
                    case Symbol.Tab:
                        if (!MoveToNextToken())
                        {
                            
                        }
                        var next = (char) _reader.Read();
                        switch (next)
                        {
                            case Symbol.Space:
                                yield return Command.InstructionModificationParameter.Arithmetic;
                                break;
                            case Symbol.Tab:
                                yield return Command.InstructionModificationParameter.HeapAccess;
                                break;
                            case Symbol.Newline:
                                yield return Command.InstructionModificationParameter.Interactive;
                                break;
                        }
                        break;
                    case Symbol.Newline:
                        yield return Command.InstructionModificationParameter.FlowControl;
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commands"></param>
        private void PushStackManipulationCommand(ICollection<Command> commands)
        {
            switch (GetToken())
            {
                case Symbol.Space:
                    var push = new Push();
                    push.Value = GetNumber();
                    commands.Add(push);
                    return;
                case Symbol.Tab:
                    switch (GetToken())
                    {
                        case Symbol.Space:
                            var copy = new Copy();
                            copy.Value = GetNumber();
                            commands.Add(copy);
                            return;
                        case Symbol.Tab:
                            break;
                        case Symbol.Newline:
                            var slide = new Slide();
                            slide.Value = GetNumber();
                            commands.Add(slide);
                            return;
                    }
                    break;
                case Symbol.Newline:
                    switch (GetToken())
                    {
                        case Symbol.Space:
                            var duplicate = new Duplicate();
                            commands.Add(duplicate);
                            return;
                        case Symbol.Tab:
                            var swap = new Swap();
                            commands.Add(swap);
                            return;
                        case Symbol.Newline:
                            var discard = new Discard();
                            commands.Add(discard);
                            return;
                    }
                    break;
            }
            throw new SyntaxException("Invalid command, [Stack Manipulation]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commands"></param>
        private void PushArithmeticCommand(ICollection<Command> commands)
        {
            switch (GetToken())
            {
                case Symbol.Space:
                    switch (GetToken())
                    {
                        case Symbol.Space:
                            var addition = new Addition();
                            commands.Add(addition);
                            return;
                        case Symbol.Tab:
                            var subtraction = new Subtraction();
                            commands.Add(subtraction);
                            return;
                        case Symbol.Newline:
                            var multiplication = new Multiplication();
                            commands.Add(multiplication);
                            return;
                    }
                    break;
                case Symbol.Tab:
                    switch (GetToken())
                    {
                        case Symbol.Space:
                            var division = new Division();
                            commands.Add(division);
                            return;
                        case Symbol.Tab:
                            var modulo = new Modulo();
                            commands.Add(modulo);
                            return;
                    }
                    break;
            }
            throw new SyntaxException("Invalid command, [Arithmetic]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commands"></param>
        private void PushHeapAccessCommand(ICollection<Command> commands)
        {
            switch (GetToken())
            {
                case Symbol.Space:
                    var store = new Store();
                    commands.Add(store);
                    return;
                case Symbol.Tab:
                    var retrieve = new Retrieve();
                    commands.Add(retrieve);
                    return;
                case Symbol.Newline:
                    break;
            }
            throw new SyntaxException("Invalid command, [Heap Access]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commands"></param>
        private void PushFlowControlCommand(ICollection<Command> commands)
        {
            switch (GetToken())
            {
                case Symbol.Space:
                    switch (GetToken())
                    {
                        case Symbol.Space:
                            var register = new Register();
                            register.Name = GetLiteral();
                            register.Location = commands.Count;
                            commands.Add(register);
                            return;
                        case Symbol.Tab:
                            var call = new Call();
                            call.Name = GetLiteral();
                            call.Location = commands.Count;
                            commands.Add(call);
                            return;
                        case Symbol.Newline:
                            var jump = new Jump();
                            jump.Name = GetLiteral();
                            commands.Add(jump);
                            return;
                    }
                    break;
                case Symbol.Tab:
                    switch (GetToken())
                    {
                        case Symbol.Space:
                            var equal = new Test();
                            equal.Name = GetLiteral();
                            equal.Compare = (x => x == 0);
                            commands.Add(equal);
                            return;
                        case Symbol.Tab:
                            var less = new Test();
                            less.Name = GetLiteral();
                            less.Compare = (x => x < 0);
                            commands.Add(less);
                            return;
                        case Symbol.Newline:
                            var back = new Return();
                            commands.Add(back);
                            return;
                    }
                    break;
                case Symbol.Newline:
                    if (GetToken() == Symbol.Newline)
                    {
                        var end = new End();
                        commands.Add(end);
                        return;
                    }
                    break;
            }
            throw new SyntaxException("Invalid command, [Flow Control]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="commands"></param>
        private void PushInteractiveCommand(List<Command> commands)
        {
            switch (GetToken())
            {
                case Symbol.Space:
                    switch (GetToken())
                    {
                        case Symbol.Space:
                            var cOutput = new Output<char>();
                            commands.Add(cOutput);
                            return;
                        case Symbol.Tab:
                            var nOutput = new Output<int>();
                            commands.Add(nOutput);
                            return;
                    }
                    break;
                case Symbol.Tab:
                    switch (GetToken())
                    {
                        case Symbol.Space:
                            var cInput = new Input<char>();
                            commands.Add(cInput);
                            return;
                        case Symbol.Tab:
                            var nInput = new Input<int>();
                            commands.Add(nInput);
                            return;
                    }
                    break;
            }
            throw new SyntaxException("Invalid command, [Interactive]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetNumber()
        {
            return Convert.ToInt32(GetLiteral(), 2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetLiteral()
        {
            var builder = new StringBuilder();
            while (MoveToNextToken())
            {
                var character = (char) _reader.Read();
                switch (character)
                {
                    case Symbol.Space:
                        builder.Append(0);
                        break;
                    case Symbol.Tab:
                        builder.Append(1);
                        break;
                    case Symbol.Newline:
                        return builder.ToString();
                }
            }
            throw new SyntaxException("Syntax error, Token is not enough");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private char GetToken()
        {
            if (!MoveToNextToken())
            {
                throw new SyntaxException("Syntax error, Token is not enough");
            }
            return (char) _reader.Read();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool MoveToNextToken()
        {
            while (!_reader.EndOfStream)
            {
                var character = (char)_reader.Peek();
                if (Symbol.Is(character))
                {
                    return true;
                }
                _reader.Read();
            }
            return false;
        }
    }
}
