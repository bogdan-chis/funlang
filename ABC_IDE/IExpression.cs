using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_IDE
{
        public interface IExpression : ICloneable
        {
            FType GetFType();
            IExpression Eval(Env env);
            bool Equals(Object obj);
            int Compare(IExpression exp);
            bool IsTrue();

            Token Tok { get; set; }
        }

        public enum FType
        {
            FNumber,
            FChar,
            FSymbol,
            FList,
            FFunction,
            FDefine,
            FCallable,
            FIf,
            FFunctionator,
        }
}
