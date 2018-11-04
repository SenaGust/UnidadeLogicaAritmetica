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
            return Or(Or(a, b), Or(c, d));
        }
        public bool Or(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h)
        {
            return Or( Or(Or(a, b), Or(c, d)), Or(Or(e, f), Or(g, h)));
        }
    }
}
