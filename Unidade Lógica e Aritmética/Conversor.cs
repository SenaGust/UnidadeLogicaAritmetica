﻿using System;
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
        public bool[] DecimalBinario()
        {
            return null;
        }
        public bool[] Complemento2()
        {
            return null;
        }
        public int BinarioParaInteiro(bool[] vetBin)
        {
            int numero = 0;

            for (int i = (vetBin.Length - 1); i > -1; i--)
                if (vetBin[i])
                    numero += Convert.ToInt32(Math.Pow(2, i));

            return numero;
        }
        public float BinarioParaFloat()
        {
            return 0;
        }
        public string BinarioParaHexadecimal(bool[] vetBin)
        {
            //bool[] seg = new bool[4];
            //int pos = 0;

            //for (int i = (vetBin.Length - 1); i > -1; i--)
            //{
            //    if (pos < 4)
            //    {
            //        seg[pos] = vetBin[i];
            //        pos++;
            //    }                    
            //    else
            //    {
            //        switch (seg)
            //        {
            //            case 0000:
            //        }
            //    }
                   
            //}
                
           

            
            return null;
        }
    }
}
