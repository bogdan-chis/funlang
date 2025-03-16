using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_IDE
{
    public class FFunction : IExpression
	{
		public List<FSymbol> parameters;
		public IExpression body;
		public Token Tok { get; set; }

		public FFunction(List<FSymbol> _parameters, IExpression _body, Token _tok)
		{
			parameters = _parameters;
			body = _body;
			Tok = _tok;
		}

		public IExpression Eval(Env env) {return this;}

		public FCallable GetFCallable() {return new FunctionCall(parameters, body, Tok, true);}

		public override string ToString()
		{
			var res = "";
			foreach (var p in parameters)
			{
				res += p.ToString() + " ";
			}
			if (parameters.Count > 0)
			{
				res = res.Remove(res.Length - 1);
			}
			return String.Format("func ({0}) => {1}", res, body);
		}
		public override bool Equals(Object obj)
		{
            if (obj == null || !(obj is IExpression))
            {
                return false;
            }
            var exp = (IExpression)obj;

            if (exp.GetFType() != FType.FFunction) return false;
			var other = (FFunction)exp;
			if (parameters.Count != other.parameters.Count) return false;
			for (int i = 0; i < parameters.Count; ++i)
			{
				if (!this.parameters[i].Equals(other.parameters[i])) return false;
			}
			return this.body.Equals(other.body);
		}
        public int Compare(IExpression exp) {return  (this.Equals(exp)) ? 0 : -1;}
		public bool IsTrue() {return true;}

        public object Clone()
		{
			var clone_params = new List<FSymbol>();
			foreach (var param in parameters)
			{
				clone_params.Add((FSymbol)param.Clone());
			}
			return new FFunction(clone_params, (IExpression)body.Clone(), (Token)Tok.Clone());
		}
        public FType GetFType() { return FType.FFunction; }
	}
}
