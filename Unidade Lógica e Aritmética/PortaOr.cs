using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class PortaOr
    {
        public bool Or(bool a, bool b)
        {
            return a | b;
        }
        public bool Or(bool a, bool b, bool c, bool d)
        {
            return (Or(a, b) | Or(c, d));
        }
    }
}
