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
        public bool[] complemento2(bool[] bin)
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
            //numero = -111.25f; // Apagar*********************

            // determina quantos digitos compõe a parte fracionária do número
            string numCompleto = numero.ToString(), resultInt = null, resultFracion = null, resultado = null;
            string[] numDec = numCompleto.Split(',');
            int quant_Frac = numDec[1].Length, parteInteira, resto;
            float partedecimal;
            float digitoInt = 1; // parte inteira da conversão da parte fracionária

            if (numero >= 0)
            {
                parteInteira = Convert.ToInt32(Math.Truncate(numero)); // determina a parte inteira do número
                partedecimal = Convert.ToSingle(Math.Round(numero - Convert.ToSingle(parteInteira), quant_Frac)); // determina a parte fracionária
            }
            else
            {
                parteInteira = Convert.ToInt32(numDec[0].Trim('-')); // determina a parte inteira do número
                partedecimal = Convert.ToSingle(Math.Round(numero - Convert.ToSingle(Math.Truncate(numero)), quant_Frac) * -1); // determina a parte fracionária
            }

            Console.WriteLine(partedecimal); Console.ReadKey();

            // Conversão da parte inteira (base 10 -> base 2)
            while (parteInteira > 0)
            {
                resto = parteInteira % 2;
                parteInteira /= 2;
                resultInt = resto.ToString() + resultInt;
            }

            // Conversão da parte fracionária (base 10 -> base 2)
            while (digitoInt != 0) // adicionar um tamanho limite ***************
            {
                numCompleto = (partedecimal * 2).ToString(); // armazena a parte fracionária * 2, no atributo tipo string numCompleto
                numDec = numCompleto.Split(','); // separa a parte inteira e fracionária

                resultFracion += numDec[0]; // armazena o resultado em binario no atributo tipo string resultDecimal

                if (Convert.ToSingle(numDec[0]) != 0) // se a parte inteira for diferente de zero, o valor da próxima multiplicação tem -1 subtraído
                    partedecimal = Convert.ToSingle(numCompleto) - 1;
                else
                    partedecimal = Convert.ToSingle(numCompleto);

                digitoInt = partedecimal; // será testado pelo while se a parte fracionária ainda não chegou a zero             
            }

            resultado = resultInt + resultFracion; // numero binário com parte inteira e fracionária

            int expoente = resultInt.Length * -1; // determina o valor do expoente baseado em quantas 'casas' a vírgula vai ter que andar

            bool[] mantissa32 = new bool[32]; // cria o vetor para armazenar a mantissa de 32 bits

            // determina o bit do sinal
            if (numero >= 0)
                mantissa32[0] = false;
            else
                mantissa32[0] = true;

            // determina o valor do expoente na base 2
            bool[] expoente8bits = InteiroParaBinario(8, expoente);

            string exp8bitsNormalizado = null;
            int expComum;

            for (int t = 0; t < expoente8bits.Length; t++)
            {
                if (expoente8bits[t])
                    exp8bitsNormalizado += 1;
                else
                    exp8bitsNormalizado += 0;
            }

            expComum = Convert.ToInt32(exp8bitsNormalizado);

            exp8bitsNormalizado = Convert.ToString(expComum - 0000011, 2);

            // grava o expoente na mantissa32
            for (int i = 1; i < 8; i++)
            {
                if (Convert.ToInt32(exp8bitsNormalizado[i - 1]) == 49) // 49 == true, 48 == false
                    mantissa32[i] = true;
                else
                    mantissa32[i] = false;
            }

            // grava a mantissa na mantissa32
            for (int x = 0; x < resultado.Length; x++)
            {
                if (Convert.ToInt32(resultado[x]) == 49)
                    mantissa32[x + 9] = true;
                else
                    mantissa32[x + 9] = false;
            }

            Console.WriteLine("resultado: " + resultado);
            Console.WriteLine("expoente (int): " + expoente);

            for (int f = 0; f < expoente8bits.Length; f++)
                Console.WriteLine("expoente8bits[{0}] = {1}", f, expoente8bits[f]);

            Console.WriteLine("expComum: " + expComum);
            Console.WriteLine("exp8bitsNormalizado:" + exp8bitsNormalizado);

            for (int g = 0; g < mantissa32.Length; g++)
                Console.WriteLine("mantissa32[{0}] = {1}", g, mantissa32[g]);

            return mantissa32;
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
