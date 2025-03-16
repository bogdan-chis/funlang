using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_IDE
{
    public class FSymbol : IExpression
    {
        public string name;
        public Token Tok { get; set; }

        public FSymbol(string _name)
        {
            name = _name;
            Tok = null;
        }

        public FSymbol(string _name, Token _tok)
        {
            name = _name;
            Tok = _tok;
        }

        public IExpression Eval(Env env)
        {
            IExpression e;
            if (env.TryGetValue(name, out e))
            {
                e.Tok = Tok;
                return e;
            }
            throw new InvalidFunProgram("Cannot find the symbol " + name, Tok);
        }

        public override string ToString() {return  String.Format("{0}", name);}
        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is IExpression))
            {
                return false;
            }
            var exp = (IExpression)obj;

            if (exp.GetFType() != FType.FSymbol) return false;
            return this.name == ((FSymbol)exp).name;
        }
        public int Compare(IExpression exp)  {return this.Equals(exp) ? 0 : -1;}
        public bool IsTrue() { throw new InvalidFunProgram("Cannot evaluate truth value of FSymbol.", Tok);}

        public object Clone() {return new FSymbol(name, Tok);}
        public FType GetFType() { return FType.FSymbol; }
    }
}
