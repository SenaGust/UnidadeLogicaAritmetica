using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class UnidadeLogica1bitPontoFlutuante
    {
        Somador add = new Somador();
        Somador sub = new Somador();
        PortaOr P0 = new PortaOr();
        PortaAnd P1 = new PortaAnd();
        PortaAnd P2 = new PortaAnd();
        Decodificador decod = new Decodificador();
        
        public bool ULA1Bit(bool a, bool b, bool F, bool vem1, out bool vai1)
        {
            //a e b são os valores digitados pelo usuário
            //vetor F, reflete a escolha do usuário
            //vem 1 e vai 1 são usados pelo somador

            bool[] M = new bool[2]; //opções
            bool[] d = new bool[2]; //aquele que for verdadeiro, será a escolha do usuário
            bool[] Ma = new bool[2]; //habilita opção escolhida

            //calcula cada uma das opções
            M[0] = add.Ativa(a, b, vem1, out vai1); //soma mantissa
            M[1] = sub.Ativa(a, b, vem1, out vai1); //subrai mantissa

            //descobre qual foi a escolha do usuário
            decod.decodificadorPontoFlutuante(F, out d[0], out d[1]);

            //de acordo com a escolha do usuário, habilita a função escolhida
            Ma[0] = P1.And(M[0], d[0]); //0  soma
            Ma[1] = P2.And(M[1], d[1]); //1 sub

            return P0.Or(Ma[0], Ma[1]);
        }
    }
}
