using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class PortaXor
    {
        // XOR = ~AB + A~B
        PortaAnd P0 = new PortaAnd();
        PortaAnd P1 = new PortaAnd();
        PortaOr P2 = new PortaOr();
        PortaNot P3 = new PortaNot();
        PortaNot P4 = new PortaNot();

        public bool Xor(bool A, bool B)
        {
            bool M0, M1;
            M0 = P1.And(P3.Not(A), B);
            M1 = P1.And(A, P4.Not(B));
            return (P2.Or(M0, M1));
        }
    }
}
