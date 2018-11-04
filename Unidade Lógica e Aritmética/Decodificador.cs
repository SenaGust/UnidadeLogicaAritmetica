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
        
        public void decodificadorInteiro(bool F2, bool F1, bool F0, out bool d0, out bool d1, out bool d2, out bool d3, out bool d4, out bool d5, out bool d6, out bool d7)
        {
            PortaNot p0 = new PortaNot();
            PortaNot p1 = new PortaNot();
            PortaNot p2 = new PortaNot();
            PortaAnd p3 = new PortaAnd();
            PortaAnd p4 = new PortaAnd();

            d0 = p3.And(p4.And(p0.Not(F2), p1.Not(F1)), p2.Not(F0)); //000 - negar as três
            d1 = p3.And(p4.And(p0.Not(F2), p1.Not(F1)), F0); //001 - negar as duas primeiras
            d2 = p3.And(p4.And(p0.Not(F2), F1), p1.Not(F0)); //010 - negar a primeira e a última
            d3 = p3.And(p4.And(p0.Not(F2), F1), F0); //011 - negar a primeira
            d4 = p3.And(p4.And(F2, p1.Not(F1)), p2.Not(F0)); //100 - negar as duas últimas
            d5 = p3.And(p4.And(F2, p1.Not(F1)), F0); //101 - negar a do meio
            d6 = false; //110 - negar a última
            d7 = false; //111 -
            
        }
        public void decodificadorPontoFlutuante(bool F0, out bool d0, out bool d1)
        {
            PortaNot p0 = new PortaNot();

            d0 = p0.Not(F0);
            d1 = F0;
        }
    }
}
