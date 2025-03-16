using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_IDE
{
    [Serializable]
    public class InvalidFunProgram : Exception
    {
        public Token tok = null;

        public InvalidFunProgram(Token Tok) { tok = Tok; }

        public InvalidFunProgram(string message, Token Tok)
        : base(message) { tok = Tok; }

        public InvalidFunProgram(string message, Exception inner, Token Tok)
        : base(message, inner) { tok = Tok; }
    }
}
