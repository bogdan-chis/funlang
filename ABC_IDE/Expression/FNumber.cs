using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_IDE
{
	public class FNumber : IExpression
	{
		public int i;
		public float f;
        public bool isInt;
        public bool isFloat;
        public Token Tok { get; set; }

		public FNumber(int _i, Token _tok)
		{
			i = _i;
			f = 0.0f;
            isInt = true;
            isFloat = false;
            Tok = _tok;
		}

		public FNumber(float _f, Token _tok)
		{
			f = _f;
			i = 0;
            isInt = false;
            isFloat = true;
			Tok = _tok;
		}

		public IExpression Eval(Env env) { return this;}

		public override string ToString()
		{
			if (isInt)
			{
				return String.Format("{0}", i);
			}
			else if (isFloat)
			{
				return String.Format("{0}", f);
			}
			return String.Format("NaN");
		}
		public override bool Equals(Object obj)
		{
            if (obj == null || !(obj is IExpression))
            {
                return false;
            }
			var exp = (IExpression) obj;

			if (exp.GetFType() == FType.FNumber)
			{
				var num = (FNumber)exp;
				if (isInt && num.isInt)
				{
					return (i == num.i);
				}
				else
				{
					float f1 = (isInt) ? (float)i : f;
					float f2 = (num.isInt) ? (float)num.i : num.f;
					return Math.Abs((double)(f1 - f2)) < 0.000001;
				}
			}
			else if (exp.GetFType() == FType.FChar)
			{
                var ch = (FChar)exp;
				if (isInt) return ch.ch == i;
				return false;
            }
			return false;
        }
		public int Compare(IExpression exp)
		{
			if (this.Equals(exp)) return 0;
			else if (exp.GetFType() == FType.FNumber)
			{
				var num = (FNumber)exp;
				if (isInt && num.isInt)
				{
					return (i > num.i) ? 1 : -1;
				}
				float f1 = (isInt) ? (float)i : f;
				float f2 = (num.isInt) ? (float)num.i : num.f;
				return (f1 > f2) ? 1 : -1;
			}
			else if (exp.GetFType() == FType.FChar)
			{
				var ch = (FChar)exp;
				var val = (isInt) ? (float)i : f;
				return (val > ch.ch) ? 1 : -1;
			}

			return 1;
		}
		public bool IsTrue() {return !this.Equals(new FNumber(0, null)); }

		public object Clone()
		{
			if (isInt)
			{
				return new FNumber(i, Tok);
			}
			else
			{
				return new FNumber(f, Tok);
			}
		}
        public FType GetFType() { return FType.FNumber; }
	}
}
