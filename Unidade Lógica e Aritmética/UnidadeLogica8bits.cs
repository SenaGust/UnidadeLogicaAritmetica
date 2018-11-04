using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class UnidadeLogica8bits
    {
        UnidadeLogica1bit ALU7 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU6 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU5 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU4 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU3 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU2 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU1 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU0 = new UnidadeLogica1bit();

        /*
         * Tabela
         * F2 F1 F0 Saída
         * 0  0  0  A and B
         * 0  0  1  A or B
         * 0  1  0  Not A
         * 0  1  1  Not B
         * 1  0  0  A + B
         * 1  0  1  A - B
         * 1  1  0    -
         * 1  1  1    -
         */
        
        public bool ULA8Bits(bool[] a, bool[] b, bool[] f, bool[] s)
        {
            bool vai1, vem1 = false;
            s[7] = ALU7.ULA1Bit(a[7], b[7], f, vem1, out vai1);
            vem1 = vai1;
            s[6] = ALU7.ULA1Bit(a[6], b[6], f, vem1, out vai1);
            vem1 = vai1;
            s[5] = ALU7.ULA1Bit(a[5], b[5], f, vem1, out vai1);
            vem1 = vai1;
            s[4] = ALU7.ULA1Bit(a[4], b[4], f, vem1, out vai1);
            vem1 = vai1;
            s[3] = ALU7.ULA1Bit(a[3], b[3], f, vem1, out vai1);
            vem1 = vai1;
            s[2] = ALU7.ULA1Bit(a[2], b[2], f, vem1, out vai1);
            vem1 = vai1;
            s[1] = ALU7.ULA1Bit(a[1], b[1], f, vem1, out vai1);
            vem1 = vai1;
            s[0] = ALU7.ULA1Bit(a[0], b[0], f, vem1, out vai1);
            return vai1;
        }
    }
}
