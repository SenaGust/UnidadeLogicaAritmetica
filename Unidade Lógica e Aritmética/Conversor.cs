using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidade_Lógica_e_Aritmética
{
    class Conversor
    {
        #region Positivos
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
        public int BinarioParaInteiro(bool[] vetBin)
        {
            int numero = 0;

            for (int i = (vetBin.Length - 1); i >= 0; i--)
                if (vetBin[i])
                    numero += Convert.ToInt32(Math.Pow(2, (vetBin.Length - 1) - i));

            return numero;
        }
        #endregion

        #region Negativos
        public bool[] decimalParaComplemento2(bool[] bin)
        {
            bool[] resultado = new bool[bin.Length];
            bool[] f = new bool[3];

            if (bin.Length == 8) //8 bits
            {
                bool[] um = { false, false, false, false, false, false, false, true };
                UnidadeLogica8bits ula = new UnidadeLogica8bits();

                f[0] = true; f[1] = true; f[2] = false; //0  1  1  Not B
                ula.ULA8Bits(um, bin, f, resultado);

                bin = resultado;

                f[0] = false; f[1] = false; f[2] = true; //1  0  0  A + B
                ula.ULA8Bits(um, bin, f, resultado);
            }
            else //24 bits
            {
                UnidadeLogica24bits ula = new UnidadeLogica24bits();
                bool[] um = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true };

                f[0] = true; f[1] = true; f[2] = false; //0  1  1  Not B
                ula.ULA24Bits(um, bin, f, resultado);

                bin = resultado;

                f[0] = false; f[1] = false; f[2] = true; //1  0  0  A + B
                ula.ULA24Bits(um, bin, f, resultado);
            }

            return resultado;
        }
        public int complemento2ParaDecimal(bool[] bin)
        {
            double soma = 0; 
            
            if (bin[0]) //se bin[0] for false, a formula dá 0
                soma = Math.Pow(-2, bin.Length - 1);

            for (int pos = 1; pos < bin.Length; pos++)
            {
                if (bin[pos])
                    soma += Math.Pow(2, bin.Length - 1 - pos);
            }

            return Convert.ToInt32(soma);
        }
        #endregion

        #region Hexadecimal
        public string BinarioParaHexadecimal(bool[] vetBin)
        {
            string seg = null, numB16 = null; // seg (segmento do número), numB16 ( número base 16)
            int pos = 0; // posição

            for (int i = 0; i <= (vetBin.Length); i++)
            {
                if (pos < 4 && i < vetBin.Length) // converte os valores binarios em segmentos de quatro digitos por vez
                {
                    // converte os valores do vetBin de true/false para 1/0
                    if (vetBin[i])
                        seg += "1";
                    else
                        seg += "0";

                    pos++; // segue para o próximo digito
                } // if
                else // depois que o atributo seg já possui quatro digitos do número, esses números são convertidos para o simbolo equivalente da base 16
                {
                    switch (seg)
                    {
                        case "0000":
                            numB16 += 0; break;
                        case "0001":
                            numB16 += 1; break;
                        case "0010":
                            numB16 += 2; break;
                        case "0011":
                            numB16 += 3; break;
                        case "0100":
                            numB16 += 4; break;
                        case "0101":
                            numB16 += 5; break;
                        case "0110":
                            numB16 += 6; break;
                        case "0111":
                            numB16 += 7; break;
                        case "1000":
                            numB16 += 8; break;
                        case "1001":
                            numB16 += 9; break;
                        case "1010":
                            numB16 += "A"; break;
                        case "1011":
                            numB16 += "B"; break;
                        case "1100":
                            numB16 += "C"; break;
                        case "1101":
                            numB16 += "D"; break;
                        case "1110":
                            numB16 += "E"; break;
                        case "1111":
                            numB16 += "F"; break;
                        default:
                            numB16 += "ERRO"; break;
                    } // switch

                    pos = 0; // a posição é resetada para 0 (primeiro digito do próximo segmento de quatro digitos
                    seg = null; // o atributo que armazena os valores do seção de quatro digitos do números binário é inicializado como 'null'

                    if (i != vetBin.Length) // se existirem mais grupos compostos por quatro digitos binários é subtraido 1 do atributo 'i' do for 
                        i--;                // para compensar a repetição que foi gasta para converter os digitos binários para hexadecimal
                } // else
            } // for

            return numB16; // retorna o número na base 16
        }
        #endregion

        #region Ponto Flutuante
        public bool[] PontoFlutuanteParaBinario(float numero)
        {
            return null;
        }
        public float BinarioParaFloat()
        {
            return 0;
        }
        #endregion

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
