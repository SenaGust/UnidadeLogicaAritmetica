using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class Somador
    {
        /*
         * Somador de 1 bits
         */

        public class Adder
        {
            PortaAnd P0 = new PortaAnd();
            PortaAnd P1 = new PortaAnd();
            PortaOr P2 = new PortaOr();
            PortaXor P3 = new PortaXor();
            PortaXor P4 = new PortaXor();
            public bool Ativa(bool A, bool B, bool Vem1, out bool Vai1)
            {
                bool M0, M1, M2, SOMA;
                M0 = P0.And(A, B);
                M1 = P3.Xor(A, B);
                M2 = P1.And(M1, Vem1);
                Vai1 = P2.Or(M0, M2);
                SOMA = P4.Xor(M1, Vem1);
                return (SOMA);
            }
        }

    }
}
