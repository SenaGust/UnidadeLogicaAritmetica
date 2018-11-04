using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class UnidadeLogica24bits
    {
        UnidadeLogica1bit ALU23 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU22 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU21 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU20 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU19 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU18 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU17 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU16 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU15 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU14 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU13 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU12 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU11 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU10 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU9 = new UnidadeLogica1bit();
        UnidadeLogica1bit ALU8 = new UnidadeLogica1bit();
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
            s[23] = ALU7.ULA1Bit(a[23], b[23], f, vem1, out vai1);
            vem1 = vai1;
            s[22] = ALU7.ULA1Bit(a[22], b[22], f, vem1, out vai1);
            vem1 = vai1;
            s[21] = ALU7.ULA1Bit(a[21], b[21], f, vem1, out vai1);
            vem1 = vai1;
            s[20] = ALU7.ULA1Bit(a[20], b[20], f, vem1, out vai1);
            vem1 = vai1;
            s[19] = ALU7.ULA1Bit(a[19], b[19], f, vem1, out vai1);
            vem1 = vai1;
            s[18] = ALU7.ULA1Bit(a[18], b[18], f, vem1, out vai1);
            vem1 = vai1;
            s[17] = ALU7.ULA1Bit(a[17], b[17], f, vem1, out vai1);
            vem1 = vai1;
            s[16] = ALU7.ULA1Bit(a[16], b[16], f, vem1, out vai1);
            vem1 = vai1;
            s[15] = ALU7.ULA1Bit(a[15], b[15], f, vem1, out vai1);
            vem1 = vai1;
            s[14] = ALU7.ULA1Bit(a[14], b[14], f, vem1, out vai1);
            vem1 = vai1;
            s[13] = ALU7.ULA1Bit(a[13], b[13], f, vem1, out vai1);
            vem1 = vai1;
            s[12] = ALU7.ULA1Bit(a[12], b[12], f, vem1, out vai1);
            vem1 = vai1;
            s[11] = ALU7.ULA1Bit(a[11], b[11], f, vem1, out vai1);
            vem1 = vai1;
            s[10] = ALU7.ULA1Bit(a[10], b[10], f, vem1, out vai1);
            vem1 = vai1;
            s[9] = ALU7.ULA1Bit(a[9], b[9], f, vem1, out vai1);
            vem1 = vai1;
            s[8] = ALU7.ULA1Bit(a[8], b[8], f, vem1, out vai1);
            vem1 = vai1;
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
