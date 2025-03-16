using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_IDE
{
    public class Env : Dictionary<string, IExpression>, ICloneable
    {
		public void AddStandard() {
			this["+"] = new Add();
            this["-"] = new Substract();
            this["*"] = new Multiply();
            this["/"] = new Divide();
            this["%"] = new Modulo();

            this["=="] = new Equal();
            this["!="] = new Different();
            this[">"] = new Greater();
            this[">="] = new GreaterEq();
            this["<"] = new Less();
            this["<="] = new LessEq();

            this["not"] = new Not();
            this["or"] = new Or();
            this["and"] = new And();

            this["length"] = new Length();
            this["first"] = new First();
            this["second"] = new Second();
            this["third"] = new Third();
            this["last"] = new Last();
            this["head"] = new Head();
            this["tail"] = new Tail();
            this["empty"] = new Empty();
            this["push"] = new Push();
            this["append"] = new Append();
            this["range"] = new Range();

            this["println"] = new Println();
            this["error"] = new Error();
            this["readln"] = new Readln();

            this["num"] = new Num();
            this["char"] = new Char();
        }

		public void AddArguments(List<FSymbol> parameters, FList arguments)
		{
			for(int i = 0; i < parameters.Count; ++i)
			{
                this[parameters[i].name] = arguments[i];
            }
		}

        public object Clone()
        {
            Env clone = new Env();
            foreach (var p in this)
            {
                clone[p.Key] = (IExpression) (p.Value.Clone());
            }
            return clone;
        }
    }
}
