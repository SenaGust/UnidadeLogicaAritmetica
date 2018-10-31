using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class Conversor
    {
        /* 
         * Conversão decimal binário
         * Complemento - 2 (trocar sinal)
         * Conversão binário para inteiro
         * Conversão binário para ponto flutuante
         * Conversão binário para hexadecimal
         */
        public bool[] InteiroParaBinario(int tamanho, int numero)
        {
            bool[] resultado = new bool[tamanho];

            for (int pos = tamanho - 1; pos >= 0; pos--)
            {
                if (numero % 2 == 0)
                {
                    resultado[pos] = false;
                }
                else //numero%2 == 1
                {
                    resultado[pos] = true;
                }
                numero /= 2;
            }

            return resultado;
        }
        public bool[] PontoFlutuanteParaBinario(float numero)
        {
            return null;
        }
        public bool[] Complemento2()
        {
            return null;
        }
        public int BinarioParaInteiro()
        {
            return 0;
        }
        public float BinarioParaFloat()
        {
            return 0;
        }
        public string BinarioParaHexadecimal(string numero)
        {
            return null;
        }

        public string imprimirBinario(bool[] bin)
        {
            //não sei se isso pode ficar aqui, mas vai ser útil (Gustavo)
            string result = null;

            for (int pos = 0; pos < bin.Length; pos++)
            {
                if (bin[pos])
                    result += "1";
                else
                    result += "0";
            }

            return result;  
        }
    }
}
