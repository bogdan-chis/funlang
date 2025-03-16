using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_IDE
{
	public abstract class FCallable : IExpression
	{
        public List<FSymbol> parameters = new List<FSymbol>();
		public Env env = new Env();
		public bool isClosure;
		public Token Tok { get; set; }
		

		public abstract IExpression Eval(Env env);

		public int ParamCount() {return parameters.Count;}
		
		public override bool Equals(Object obj)
        {
            return obj is FCallable;
        }
        public int Compare(IExpression exp) {return this.Equals(exp) ? 0 : -1;}
        public bool IsTrue() {return true;}

        public abstract object Clone();
		public FType GetFType() {return FType.FCallable;}
	}

	public class Add : FCallable
	{
		public Add()
		{
			var x = new FSymbol("__x__");
			var y = new FSymbol("__y__");
			isClosure = false;

			parameters.Add(x);
			parameters.Add(y);
		}

		public override IExpression Eval(Env env)
		{
			var arg1 = env[parameters[0].name];
			var arg2 = env[parameters[1].name];

			if (arg1.GetFType() == FType.FChar)
			{
				var num = new FNumber(((FChar)arg1).ch, null);
				arg1 = num;
			}
            if (arg2.GetFType() == FType.FChar)
            {
                var num = new FNumber(((FChar)arg2).ch, null);
                arg2 = num;
            }

            if (arg1.GetFType() == FType.FNumber && arg2.GetFType() == FType.FNumber)
            {
                FNumber v1 = (FNumber)arg1;
                FNumber v2 = (FNumber)arg2;
                if (v1.isInt && v2.isInt)
                {
                    return new FNumber(v1.i + v2.i, null);
                }
                else
                {
                    float f1 = (v1.isInt) ? (float)v1.i : v1.f;
                    float f2 = (v2.isInt) ? (float)v2.i : v2.f;
                    return new FNumber(f1 + f2, null);
                }
            }

            throw new InvalidFunProgram(String.Format("Cannot add {0} and {1}.", arg1.GetFType(), arg2.GetFType()), Tok);
        }

		public override object Clone() {return new Add();}
	}

	public class Substract : FCallable
	{
		public Substract()
		{
			var x = new FSymbol("__x__");
			var y = new FSymbol("__y__");
			isClosure = false;

			parameters.Add(x);
			parameters.Add(y);
		}

		public override IExpression Eval(Env env)
		{
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];

            if (arg1.GetFType() == FType.FChar)
            {
                var num = new FNumber(((FChar)arg1).ch, null);
                arg1 = num;
            }
            if (arg2.GetFType() == FType.FChar)
            {
                var num = new FNumber(((FChar)arg2).ch, null);
                arg2 = num;
            }

            if (arg1.GetFType() == FType.FNumber && arg2.GetFType() == FType.FNumber)
            {
                FNumber v1 = (FNumber)arg1;
                FNumber v2 = (FNumber)arg2;
                if (v1.isInt && v2.isInt)
                {
                    return new FNumber(v1.i - v2.i, null);
                }
                else
                {
                    float f1 = (v1.isInt) ? (float)v1.i : v1.f;
                    float f2 = (v2.isInt) ? (float)v2.i : v2.f;
                    return new FNumber(f1 - f2, null);
                }
            }

            throw new InvalidFunProgram(String.Format("Cannot subtract {0} from {1}.", arg1.GetFType(), arg2.GetFType()), Tok);

        }

        public override object Clone() {return new Substract();}
    }

	public class Multiply : FCallable
	{
		public Multiply()
		{
			var x = new FSymbol("__x__");
			var y = new FSymbol("__y__");
			isClosure = false;

			parameters.Add(x);
			parameters.Add(y);
		}

		public override IExpression Eval(Env env)
		{
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];

            if (arg1.GetFType() == FType.FChar)
            {
                var num = new FNumber(((FChar)arg1).ch, null);
                arg1 = num;
            }
            if (arg2.GetFType() == FType.FChar)
            {
                var num = new FNumber(((FChar)arg2).ch, null);
                arg2 = num;
            }

            if (arg1.GetFType() == FType.FNumber && arg2.GetFType() == FType.FNumber)
            {
                FNumber v1 = (FNumber)arg1;
                FNumber v2 = (FNumber)arg2;
                if (v1.isInt && v2.isInt)
                {
                    return new FNumber(v1.i * v2.i, null);
                }
                else
                {
                    float f1 = (v1.isInt) ? (float)v1.i : v1.f;
                    float f2 = (v2.isInt) ? (float)v2.i : v2.f;
                    return new FNumber(f1 * f2, null);
                }
            }

            throw new InvalidFunProgram(String.Format("Cannot multiply {0} and {1}.", arg1.GetFType(), arg2.GetFType()), Tok);

        }

        public override object Clone() {return new Multiply();}
    }

    public class Divide : FCallable
    {
        public Divide()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];

            if (arg1.GetFType() == FType.FChar)
            {
                var num = new FNumber(((FChar)arg1).ch, null);
                arg1 = num;
            }
            if (arg2.GetFType() == FType.FChar)
            {
                var num = new FNumber(((FChar)arg2).ch, null);
                arg2 = num;
            }

            if (arg1.GetFType() == FType.FNumber && arg2.GetFType() == FType.FNumber)
            {
                FNumber v1 = (FNumber)arg1;
                FNumber v2 = (FNumber)arg2;
                
                float f1 = (v1.isInt) ? (float)v1.i : v1.f;
                float f2 = (v2.isInt) ? (float)v2.i : v2.f;
                return new FNumber(f1 / f2, null);
            }

            throw new InvalidFunProgram(String.Format("Cannot divide {0} by {1}.", arg1.GetFType(), arg2.GetFType()), Tok);

        }

        public override object Clone() {return new Divide();}
    }

    public class Modulo : FCallable
    {
        public Modulo()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
			if(arg1.GetFType() != FType.FNumber || arg2.GetFType() != FType.FNumber)
			{
                throw new InvalidFunProgram(String.Format("Cannot calculate {0} modulo {1} (numbers must be integers).", arg1.GetFType(), arg2.GetFType()), Tok);
            }
			var num1 = (FNumber)arg1;
            var num2 = (FNumber)arg2;

            if (num1.isFloat || num2.isFloat)
            {
                throw new InvalidFunProgram(String.Format("Cannot calculate {0} modulo {1} (numbers must be integers).", arg1.GetFType(), arg2.GetFType()), Tok);
            }

            return new FNumber(num1.i % num2.i, null);
        }

        public override object Clone() {return new Modulo();}
    }

    public class Equal : FCallable
    {
        public Equal()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
            return (arg1.Equals(arg2)) ? new FNumber(1, Tok) : new FNumber(0, Tok);
        }

        public override object Clone() {return new Equal();}
    }

    public class Different : FCallable
    {
        public Different()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
            return (!arg1.Equals(arg2)) ? new FNumber(1, Tok) : new FNumber(0, Tok);
        }

        public override object Clone() {return new Different();}
    }

    public class Greater : FCallable
    {
        public Greater()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
            return (arg1.Compare(arg2) > 0) ? new FNumber(1, Tok) : new FNumber(0, Tok);
        }

        public override object Clone() {return new Greater();}
    }

    public class GreaterEq : FCallable
    {
        public GreaterEq()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
            return (arg1.Compare(arg2) >= 0) ? new FNumber(1, Tok) : new FNumber(0, Tok);
        }

        public override object Clone() {return new GreaterEq();}
    }

    public class Less : FCallable
    {
        public Less()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
            return (arg1.Compare(arg2) < 0) ? new FNumber(1, Tok) : new FNumber(0, Tok);
        }

        public override object Clone() {return new Less();}
    }

    public class LessEq : FCallable
    {
        public LessEq()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
            return (arg1.Compare(arg2) <= 0) ? new FNumber(1, Tok) : new FNumber(0, Tok);
        }

        public override object Clone() {return new LessEq();}
    }

    public class Not : FCallable
    {
        public Not()
        {
            var x = new FSymbol("__x__");
            isClosure = false;

            parameters.Add(x);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            return (arg1.IsTrue()) ? new FNumber(0, Tok) : new FNumber(1, Tok);
        }

        public override object Clone() {return new Not();}
    }

    public class Or : FCallable
    {
        public Or()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
            return (arg1.IsTrue() || arg2.IsTrue()) ? new FNumber(1, Tok) : new FNumber(0, Tok);
        }

        public override object Clone() {return new Or();}
    }

    public class And : FCallable
    {
        public And()
        {
            var x = new FSymbol("__x__");
            var y = new FSymbol("__y__");
            isClosure = false;

            parameters.Add(x);
            parameters.Add(y);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
            return (arg1.IsTrue() && arg2.IsTrue()) ? new FNumber(1, Tok) : new FNumber(0, Tok);
        }

        public override object Clone() {return new And();}
    }

    public class Length : FCallable
	{
		public Length()
		{
			var l = new FSymbol("__l__");
			isClosure = false;

			parameters.Add(l);
		}

		public override IExpression Eval(Env env)
		{
			var arg1 = env[parameters[0].name];
			if (arg1.GetFType() == FType.FList)
				return new FNumber(((FList)arg1).Count(), null);
			else
				throw new InvalidFunProgram(String.Format("Input for 'length' must be a list, got {0}.", arg1.GetFType()), Tok);
		}

        public override object Clone() {return new Length();}
    }

	public class First : FCallable
	{
		public First()
		{
			var l = new FSymbol("__l__");
			isClosure = false;

			parameters.Add(l);
		}

		public override IExpression Eval(Env env)
		{
			var arg1 = env[parameters[0].name];
			if (arg1.GetFType() == FType.FList) {
				var l = (FList)arg1;
				if (l.Count >= 1)
					return l[0];
				else
					throw new InvalidFunProgram("List too short", Tok);
			} else
                throw new InvalidFunProgram(String.Format("Input for 'first' must be a list, got {0}.", arg1.GetFType()), Tok);
        }

        public override object Clone() {return new First();}
    }

	public class Second : FCallable
	{
		public Second()
		{
			var l = new FSymbol("__l__");
			isClosure = false;

			parameters.Add(l);
		}

		public override IExpression Eval(Env env)
		{
			var arg1 = env[parameters[0].name];
			if (arg1.GetFType() == FType.FList)
			{
				var l = (FList)arg1;
				if (l.Count >= 2)
					return l[1];
				else
					throw new InvalidFunProgram("List too short", Tok);
			}
			else
                throw new InvalidFunProgram(String.Format("Input for 'second' must be a list, got {0}.", arg1.GetFType()), Tok);
        }

        public override object Clone() {return new Second();}
    }

    public class Third : FCallable
    {
        public Third()
        {
            var l = new FSymbol("__l__");
            isClosure = false;

            parameters.Add(l);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            if (arg1.GetFType() == FType.FList)
            {
                var l = (FList)arg1;
                if (l.Count >= 3)
                    return l[2];
                else
                    throw new InvalidFunProgram("List too short", Tok);
            }
            else
                throw new InvalidFunProgram(String.Format("Input for 'third' must be a list, got {0}.", arg1.GetFType()), Tok);
        }

        public override object Clone() {return new Third();}
    }

    public class Last : FCallable
    {
        public Last()
        {
            var l = new FSymbol("__l__");
            isClosure = false;

            parameters.Add(l);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            if (arg1.GetFType() == FType.FList)
            {
                var l = (FList)arg1;
                if (l.Count >= 1)
                    return l[l.Count - 1];
                else
                    throw new InvalidFunProgram("List too short to take last element", Tok);
            }
            else
                throw new InvalidFunProgram(String.Format("Input for 'last' must be a list, got {0}.", arg1.GetFType()), Tok);
        }

        public override object Clone() {return new Last();}
    }

    public class Empty : FCallable
    {
        public Empty()
        {
            var l = new FSymbol("__l__");
            isClosure = false;

            parameters.Add(l);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            if (arg1.GetFType() == FType.FList)
            {
                return new FNumber((((FList)arg1).Count == 0) ? 1 : 0, Tok);
            }
            else
                throw new InvalidFunProgram(String.Format("Input for 'empty' must be a list, got {0}.", arg1.GetFType()), Tok);
        }

        public override object Clone() {return new Empty();}
    }

    public class Tail : FCallable
	{
		public Tail()
		{
			var l = new FSymbol("__l__");
			isClosure = false;

			parameters.Add(l);
		}

		public override IExpression Eval(Env env)
		{
			var arg1 = env[parameters[0].name];
			if (arg1.GetFType() == FType.FList)
			{
				var l = (FList)arg1;
				if (l.Count >= 1)
				{
					var res = (FList)l.Clone();
					res.RemoveAt(0);
					return res;
				}
				else
					throw new InvalidFunProgram("List must have at least one element to take its tail", Tok);
			}
			else
                throw new InvalidFunProgram(String.Format("Input for 'tail' must be a list, got {0}.", arg1.GetFType()), Tok);
        }

        public override object Clone() {return new Tail();}
    }

    public class Head : FCallable
    {
        public Head()
        {
            var l = new FSymbol("__l__");
            isClosure = false;

            parameters.Add(l);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            if (arg1.GetFType() == FType.FList)
            {
                var l = (FList)arg1;
                if (l.Count >= 1)
                {
                    var res = (FList)l.Clone();
                    res.RemoveAt(res.Count - 1);
                    return res;
                }
                else
                    throw new InvalidFunProgram("List must have at least one element to take its head", Tok);
            }
            else
                throw new InvalidFunProgram(String.Format("Input for 'head' must be a list, got {0}.", arg1.GetFType()), Tok);
        }

        public override object Clone() {return new Head();}
    }

    public class Push : FCallable
	{
		public Push()
		{
			var e = new FSymbol("__e__");
			var l = new FSymbol("__l__");
			isClosure = false;

			parameters.Add(e);
			parameters.Add(l);
		}

		public override IExpression Eval(Env env)
		{
			var arg1 = env[parameters[0].name];
			var arg2 = env[parameters[1].name];
			if (arg2.GetFType() == FType.FList)
			{
				var l = (FList)((FList)arg2).Clone();

				l.Insert(0, arg1);
				return l;
			}
			else
                throw new InvalidFunProgram(String.Format("Input for 'push' must be a list, got {0}.", arg1.GetFType()), Tok);
        }

        public override object Clone() {return new Push();}
    }

    public class Append : FCallable
    {
        public Append()
        {
            var e = new FSymbol("__e__");
            var l = new FSymbol("__l__");
            isClosure = false;

            parameters.Add(e);
            parameters.Add(l);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            var arg2 = env[parameters[1].name];
            if (arg2.GetFType() == FType.FList)
            {
                var l = (FList)((FList)arg2).Clone();

                l.Add(arg1);
                return l;
            }
            else
                throw new InvalidFunProgram(String.Format("Input for 'append' must be a list, got {0}.", arg1.GetFType()), Tok);
        }

        public override object Clone() {return new Append();}
    }

    public class Println : FCallable
	{
		public Println()
		{
			var exp = new FSymbol("__exp__");
			isClosure = false;

			parameters.Add(exp);
		}

		public override IExpression Eval(Env env)
		{
			var arg1 = env[parameters[0].name];
			Console.WriteLine(arg1);

            return new FNumber(-1000, null);
        }

        public override object Clone() {return new Println();}
    }

    public class Error : FCallable
    {
        public Error()
        {
            var exp = new FSymbol("__exp__");
            isClosure = false;

            parameters.Add(exp);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            Console.Error.WriteLine("error: " + arg1);
            throw new InvalidFunProgram(Tok);
        }

        public override object Clone() {return new Error();}
    }

    public class Readln : FCallable
    {
        public Readln()
        {
            isClosure = false;
        }

        public override IExpression Eval(Env env)
        {
            var s = Console.In.ReadLine();
            if (s == null) {
                throw new InvalidFunProgram("Could not read value", Tok);
            }
            FList l = new FList(Tok);

            for (int i = 0; i < s.Length; ++i)
            {
                l.Add(new FChar(s[i], null));
            }

            return l;
        }

        public override object Clone() {return new Readln();}
    }

    public class Range : FCallable
    {
        public Range()
        {
            var n = new FSymbol("__n__");
            isClosure = false;

            parameters.Add(n);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];
            if (arg1.GetFType() != FType.FNumber)
            {
                throw new InvalidFunProgram(String.Format("Range takes a positive integer as an argument. Got: {0}", arg1.GetFType()), Tok);
            }

            var num = (FNumber)arg1;
            if (num.i == null || (num.i < 0))
            {
                throw new InvalidFunProgram(String.Format("Range takes a positive integer as an argument. Got: {0}", arg1), Tok);
            }

            FList l = new FList(Tok);
            for (int i = 0; i < num.i; ++i)
            {
                l.Add(new FNumber(i, null));
            }

            return l;  
        }

        public override object Clone() {return new Range();}
    }

    public class Num : FCallable {
        public Num()
        {
            var exp = new FSymbol("__exp__");
            isClosure = false;

            parameters.Add(exp);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];

            if (arg1.GetFType() == FType.FNumber)
                return (FNumber)arg1.Clone();

            if (arg1.GetFType() == FType.FChar)
            {
                var ch = (FChar)arg1;
                return new FNumber((int)ch.ch, Tok);
            }

            if (arg1.GetFType() == FType.FList)
            {
                var l = (FList)arg1;
                if (l.IsListOf(FType.FChar)) {
                    var res = "";
                    foreach (var el in l) {
                        var ch = (FChar)el;
                        res += ch.ch;
                    }
                    int inum;
                    float fnum;
                    if (Int32.TryParse(res, out inum))
                        return new FNumber(inum, Tok);
                    else if (float.TryParse(res, out fnum))
                        return new FNumber(fnum, Tok);
                    else
                        throw new InvalidFunProgram(String.Format("Could not convert {0} to a number", arg1), Tok);
                }
            }

            throw new InvalidFunProgram(String.Format("Could not convert {0} to a number", arg1), Tok);
        }

        public override object Clone() {return new Num();}
    }

    public class Char : FCallable
    {
        public Char()
        {
            var exp = new FSymbol("__exp__");
            isClosure = false;

            parameters.Add(exp);
        }

        public override IExpression Eval(Env env)
        {
            var arg1 = env[parameters[0].name];

            if (arg1.GetFType() == FType.FChar)
                return (FChar)arg1.Clone();

            if (arg1.GetFType() == FType.FNumber)
            {
                var num = (FNumber)arg1;
                if (num.isInt) return new FChar((char)num.i, Tok);
            }

            if (arg1.GetFType() == FType.FList)
            {
                var l = (FList)arg1;
                if (l.Count == 1 && l.IsListOf(FType.FChar))
                    return (FChar)l[0].Clone();
            }

            throw new InvalidFunProgram(String.Format("Could not convert {0} to a char", arg1), Tok);
        }

        public override object Clone() {return new Char();}
    }

    public class FunctionCall : FCallable
	{
		public IExpression body;

		public FunctionCall(List<FSymbol> _parameters, IExpression _body, Token _tok, bool _isClosure)
		{
			parameters = _parameters;
			body = _body;
			Tok = _tok;
			isClosure = _isClosure;
		}

		public override IExpression Eval(Env env)
		{
			var res = body.Eval(env);
			if (res.GetFType() == FType.FList && ((FList)res).Count >= 1)
                return ((FList)res)[((FList)res).Count - 1]; // return last element
            else
				return res;
		}

		public override object Clone()
		{
			var clone_params = new List<FSymbol>();
			foreach (var param in parameters)
			{
				clone_params.Add((FSymbol)param.Clone());
			}
			return new FunctionCall(clone_params, (IExpression)body.Clone(), (Token)Tok.Clone(), isClosure);
		}
	}
}
