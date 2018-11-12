using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class UnidadeLogica1bit
    {
        Decodificador decod = new Decodificador();
        PortaAnd P0 = new PortaAnd();
        PortaOr P1 = new PortaOr();
        PortaNot P2 = new PortaNot();
        PortaNot P3 = new PortaNot();
        Somador add = new Somador();
        Somador sub = new Somador();
        PortaAnd P4 = new PortaAnd();
        PortaAnd P5 = new PortaAnd();
        PortaAnd P6 = new PortaAnd();
        PortaAnd P7 = new PortaAnd();
        PortaAnd P8 = new PortaAnd();
        PortaAnd P9 = new PortaAnd();
        PortaOr P10 = new PortaOr();
        PortaNot P11 = new PortaNot();
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

        public bool ULA1Bit(bool a, bool b, bool[] F, bool vem1, out bool vai1) 
        {
            //a e b são os valores digitados pelo usuário
            //vetor F, reflete a escolha do usuário
            //vem 1 e vai 1 são usados pelo somador

            bool[] M = new bool[8]; //opções
            bool[] d = new bool[8]; //aquele que for verdadeiro, será a escolha do usuário
            bool[] Ma = new bool[8]; //habilita opção escolhida

            //calcula cada uma das opções
            M[0] = P0.And(a, b); //0  0  0  A and B
            M[1] = P1.Or(a, b); // 0  0  1  A or B
            M[2] = P2.Not(a); 
            M[3] = P3.Not(b);
            M[4] = add.Ativa(a, b, vem1, out vai1); //soma
            M[5] = sub.Ativa(a, b, vem1, out vai1); ; //subtração
            M[6] = false; // sem função
            M[7] = false; // sem função
            
            //descobre qual foi a escolha do usuário
            decod.decodificadorInteiro(F[2], F[1], F[0], out d[0], out d[1], out d[2], out d[3], out d[4], out d[5], out d[6], out d[7]);

            //de acordo com a escolha do usuário, habilita a função escolhida
            Ma[0] = P4.And(M[0], d[0]); //0  0  0  A and B
            Ma[1] = P5.And(M[1], d[1]); // 0  0  1  A or B
            Ma[2] = P6.And(M[2], d[2]);
            Ma[3] = P7.And(M[3], d[3]);
            Ma[4] = P8.And(M[4], d[4]);
            Ma[5] = P9.And(M[5], d[5]);
            Ma[6] = false; // sem função
            Ma[7] = false; // sem função

            return P10.Or(Ma[0], Ma[1], Ma[2], Ma[3], Ma[4], Ma[5], Ma[6], Ma[7]);
        }
    }
}
