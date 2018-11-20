using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class ShiftLogical
    {
        public static bool[] shiftLeftLogical(bool[] bin)
        {
            bool[] resposta = new bool[bin.Length];
            resposta[bin.Length - 1] = false; //ultimo tem 0
            
            for (int pos = resposta.Length - 1 -1; pos > -1; pos--)
            {
                resposta[pos] = bin[pos + 1];
            }
            return resposta;
        }

        public static bool[] shiftRightLogical(bool[] bin)
        {
            bool[] resposta = new bool[bin.Length];
            resposta[0] = false; //o primeiro tem 0
            
            for (int pos = 1; pos < resposta.Length; pos++)
            {
                resposta[pos] = bin[pos - 1];
            }
            return resposta;
        }
    }
}
