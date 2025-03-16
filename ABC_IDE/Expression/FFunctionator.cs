using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_IDE
{
	public class FFunctionator : IExpression
	{
        public Token Tok { get; set; } 

        public FFunctionator(Token _tok) { Tok = _tok; }

        public IExpression Eval(Env env) { return this;}

        public override string ToString() { return "$"; }
        public override bool Equals(Object obj)
        {
            return obj.GetType() is FFunctionator;
        }
        public int Compare(IExpression exp) { return (exp.GetFType() == FType.FFunctionator) ? 0 : -1; }
        public bool IsTrue() { throw new InvalidFunProgram("Cannot evaluate truth value of FFunctionator.", Tok); }

        public object Clone() { return new FFunctionator(Tok); } 
        public FType GetFType() {return FType.FFunctionator;}
    }
}
