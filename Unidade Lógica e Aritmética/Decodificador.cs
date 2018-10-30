using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class Decodificador
    {
        /*
         * Tabela inteiro
         * F2 F1 F0 Saída
         * 0  0  0  A and B
         * 0  0  1  A or B
         * 0  1  0  Not A
         * 0  1  1  Not B
         * 1  0  0  A + B
         * 1  0  1  A - B
         * 1  1  0    -
         * 1  1  1    -
         * 
         * 
         * Tabela ponto flutuante
         * F0 Saída
         * 0    A + B
         * 1    A - B
         * 
         */
        
        public void decodificadorInteiro()
        {

        }
        public void decodificadorPontoFlutuante()
        {

        }
    }
}
