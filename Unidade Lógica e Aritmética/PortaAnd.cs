using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class PortaAnd //Porta Lógica básica And
    {
        public bool And(bool a, bool b)
        {
            return a&b;
        }
        public bool And(bool a, bool b, bool c, bool d)
        {
            return (And(a, b) & And(c, d));
        }
    }
}
