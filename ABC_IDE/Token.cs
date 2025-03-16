using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_IDE
{
    public class Token : ICloneable
        {
            public string token;
            public int position;

            public Token(string _token, int _position)
            {
                token = _token;
                position = _position;
            }

            public string Value()
            {
                return token;
            }

            public override string ToString()
            {
                return String.Format("<{0}, {1}>", token, position);
            }

            public object Clone()
            {
                return new Token(token, position);
            }
        }
}
