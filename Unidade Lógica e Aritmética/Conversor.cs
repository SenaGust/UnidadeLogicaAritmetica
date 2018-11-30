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
        //public float BinarioParaPontoFlutuante(bool[] vet32)
        //{
        //    float mantissaB10 = 0, total;
        //    int numExpoente = 0, numSinal = 0, potencia = 0;

        //    // Converte o expoente binário para decimal
        //    for (int i = 8; i > 0; i--)
        //    {
        //        if (vet32[i])
        //            numExpoente += Convert.ToInt32(Math.Pow(2, potencia));
        //        potencia++;
        //    }

        //    potencia = 1;

        //    // Converte a mantissa binário para decimal
        //    for (int j = 9; j < vet32.Length; j++)
        //    {
        //        //float pt = Convert.ToSingle(2 ^ (j - 1));

        //        if (vet32[j])
        //            mantissaB10 += Convert.ToSingle(Math.Pow(2, (potencia * -1)));

        //        potencia++;
        //    }

        //    // testa o sinal (negativo ou positivo)
        //    if (vet32[0])
        //        numSinal = 1;

        //    float sinal = Convert.ToSingle(Math.Pow(-1, numSinal));
        //    float expoente = Convert.ToSingle(Math.Pow(2, (127 - numExpoente)));
        //    total = (sinal * (1.0f + mantissaB10) * expoente);

        //    //Console.WriteLine("\nTOTAL == " + total);

        //    //Console.WriteLine("Mantissa32:");
        //    //for (int g = 0; g < vet32.Length; g++)
        //    //{
        //    //    if (vet32[g])
        //    //        Console.Write("1 ");
        //    //    else
        //    //        Console.Write("0 ");

        //    //    if (g == 0 || g == 8)
        //    //        Console.Write("- ");
        //    //}

        //    return total;
        //}
        //public bool[] PontoFlutuanteParaBinario(float numero)
        //{
        //    // determina quantos digitos compõe a parte fracionária do número
        //    string numCompleto = numero.ToString(), resultInt = null, resultFracion = null, resultado = null;
        //    string[] numDec = numCompleto.Split(',');
        //    int quant_Frac = 0, parteInteira, resto;
        //    float partedecimal;
        //    float digitoInt = 1; // parte inteira da conversão da parte fracionária

        //    if (numDec.Length > 1)
        //        quant_Frac = numDec[1].Length;
        //    else
        //        quant_Frac = 0;

        //    if (numero >= 0)
        //    {
        //        parteInteira = Convert.ToInt32(Math.Truncate(numero)); // determina a parte inteira do número
        //        partedecimal = Convert.ToSingle(Math.Round(numero - Convert.ToSingle(parteInteira), quant_Frac)); // determina a parte fracionária
        //    }
        //    else
        //    {
        //        parteInteira = Convert.ToInt32(numDec[0].Trim('-')); // determina a parte inteira do número
        //        partedecimal = Convert.ToSingle(Math.Round(numero - Convert.ToSingle(Math.Truncate(numero)), quant_Frac) * -1); // determina a parte fracionária
        //    }

        //    //Console.WriteLine(partedecimal);

        //    // Conversão da parte inteira (base 10 -> base 2)
        //    do
        //    {
        //        resto = parteInteira % 2;
        //        parteInteira /= 2;
        //        resultInt = resto.ToString() + resultInt;
        //    }
        //    while (parteInteira != 0);

        //    // Conversão da parte fracionária (base 10 -> base 2)
        //    List<string> erroDizma = new List<string>();
        //    //bool atingiuDizma = false;

        //    // testa se os digitos fracionarios atingiram zero, ou
        //    // se a dizma nao ultrapassou 23 bits, ou
        //    // se a parte fracionaria nao eh uma dizma periodica
        //    while (digitoInt != 0 && erroDizma.Count < (24 - resultInt.Length) /*&& !atingiuDizma */)
        //    {
        //        numCompleto = (partedecimal * 2).ToString(); // armazena a parte fracionária * 2, no atributo tipo string numCompleto               
        //        numDec = numCompleto.Split(','); // separa a parte inteira e fracionária

        //        if (numDec.Length > 1)
        //        {
        //            //    // testa se a parte fracionária do número encontrado pela multiplicação da partedecimal * 2 já não foi encontrado anteriormente
        //            //    foreach (string num in erroDizma)
        //            //    {
        //            //        if (numDec[1] == num)
        //            //            atingiuDizma = true;


        //            erroDizma.Add(numDec[1]); // adiciona os resultados fracionários a lista com o intuito de detectar uma futura dizma 
        //        }
        //        resultFracion += numDec[0]; // armazena o resultado em binario no atributo tipo string resultDecimal                

        //        if (Convert.ToSingle(numDec[0]) != 0) // se a parte inteira for diferente de zero, o valor da próxima multiplicação tem -1 subtraído
        //            partedecimal = Convert.ToSingle(numCompleto) - 1;
        //        else
        //            partedecimal = Convert.ToSingle(numCompleto);

        //        digitoInt = partedecimal; // será testado pelo while se a parte fracionária ainda não chegou a zero             
        //    }

        //    resultado = resultInt.Remove(0, 1) + resultFracion; // numero binário com parte inteira e fracionária            

        //    // determina o valor do expoente baseado em quantas 'casas' a vírgula vai ter que andar para normalizar a mantissa
        //    // soma 127
        //    // e subtrai a quantidade de cases que foram "percorridas" para esquerda
        //    int expoente = (resultInt.Length + 126); // 127 - 1 (bit implicito)

        //    bool[] mantissa32 = new bool[32]; // cria o vetor para armazenar a mantissa de 32 bits

        //    // determina o bit do sinal
        //    if (numero >= 0)
        //        mantissa32[0] = false;
        //    else
        //        mantissa32[0] = true;

        //    // determina o valor do expoente na base 2
        //    bool[] expoente8bits = InteiroParaBinario(8, expoente);

        //    // grava o expoente na mantissa32
        //    for (int i = 0; i < 8; i++)
        //    {
        //        if (expoente8bits[i])
        //            mantissa32[i + 1] = true;
        //        else
        //            mantissa32[i + 1] = false;
        //    }

        //    // grava a mantissa na mantissa32
        //    for (int x = 0; x < resultado.Length; x++)
        //    {
        //        if (Convert.ToInt32(resultado[x]) == 49)
        //            mantissa32[x + 9] = true;
        //        else
        //            mantissa32[x + 9] = false;
        //    }

        //    return mantissa32;
        //}
        public float BinarioParaPontoFlutuante(bool[] vet32)
        {
            float mantissaB10 = 0, total;
            int numExpoente = 0, numSinal = 0, potencia = 0;
            bool zero = false;

            // testa se o número representado é zero
            for (int t = 0; t < vet32.Length; t++)
                if (vet32[t])
                    zero = true;

            if (!zero)
                return 0.0f;

            // Converte o expoente binário para decimal
            for (int i = 8; i > 0; i--)
            {
                if (vet32[i])
                    numExpoente += Convert.ToInt32(Math.Pow(2, potencia));
                potencia++;
            }

            potencia = 1;

            // Converte a mantissa binário para decimal
            for (int j = 9; j < vet32.Length; j++)
            {
                //float pt = Convert.ToSingle(2 ^ (j - 1));

                if (vet32[j])
                    mantissaB10 += Convert.ToSingle(Math.Pow(2, (potencia * -1)));

                potencia++;
            }

            // testa o sinal (negativo ou positivo)
            if (vet32[0])
                numSinal = 1;

            float sinal = Convert.ToSingle(Math.Pow(-1, numSinal));
            float expoente = Convert.ToSingle(Math.Pow(2, (numExpoente - 127)));
            total = (sinal * (1.0f + mantissaB10) * expoente);          

            return total;
        }

        public bool[] PontoFlutuanteParaBinario(float numero)
        {
            bool[] mantissa32 = new bool[32]; // cria o vetor para armazenar a mantissa de 32 bits

            if (numero == 0) // se o número for zero usa-se a representação reservada
            {
                for (int y = 0; y < mantissa32.Length; y++)
                    mantissa32[y] = false;

                return mantissa32;
            }
                
            // determina quantos digitos compõe a parte fracionária do número
            string numCompleto = numero.ToString(), resultInt = null, resultFracion = null, resultado = null;
            string[] numDec = numCompleto.Split(',');
            int quant_Frac = 0, parteInteira, resto;
            float partedecimal;
            float digitoInt = 1; // parte inteira da conversão da parte fracionária

            if (numDec.Length > 1)
                quant_Frac = numDec[1].Length;
            else
                quant_Frac = 0;

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

            // Conversão da parte inteira (base 10 -> base 2)
            do
            {
                resto = parteInteira % 2;
                parteInteira /= 2;
                resultInt = resto.ToString() + resultInt;
            }
            while (parteInteira != 0);

            // Conversão da parte fracionária (base 10 -> base 2)
            List<string> erroDizma = new List<string>();            

            // testa se os digitos fracionarios atingiram zero, ou
            // se a dizma nao ultrapassou 23 bits, ou
            // se a parte fracionaria nao eh uma dizma periodica
            while (/*digitoInt != 0 && */erroDizma.Count < (24 - resultInt.Length) /*&& !atingiuDizma*/)
            {
                numCompleto = (partedecimal * 2).ToString(); // armazena a parte fracionária * 2, no atributo tipo string numCompleto               
                numDec = numCompleto.Split(','); // separa a parte inteira e fracionária

                if (numDec.Length > 1)
                    erroDizma.Add(numDec[1]); // adiciona os resultados fracionários a lista com o intuito de detectar uma futura dizma periódica                
                else
                    erroDizma.Add("0");

                resultFracion += numDec[0]; // armazena o resultado em binario no atributo tipo string resultDecimal                

                if (Convert.ToSingle(numDec[0]) != 0) // se a parte inteira for diferente de zero, o valor da próxima multiplicação tem -1 subtraído
                    partedecimal = Convert.ToSingle(numCompleto) - 1;
                else
                    partedecimal = Convert.ToSingle(numCompleto);

                digitoInt = partedecimal; // será testado pelo while se a parte fracionária ainda não chegou a zero             
            }

            int expoente;

            if (resultInt != "0")
            {
                // determina o valor do expoente baseado em quantas 'casas' a vírgula vai ter que andar para normalizar a mantissa
                // soma 127
                // e subtrai a quantidade de cases que foram "percorridas" para esquerda
                expoente = (resultInt.Length + 126); // 128 - 1 (bit implicito)
                resultado = resultInt.Remove(0, 1) + resultFracion; // numero binário com parte inteira e fracionária
            }
            else
            {
                // determina o valor do expoente baseado em quantas 'casas' a vírgula vai ter que andar para normalizar a mantissa
                // soma 127
                // e subtrai a quantidade de cases que foram "percorridas" para esquerda
                expoente = ((resultInt.Length * -1) + 127); // 128 - 1 (bit implicito)
                resultado = resultFracion.Remove(0, 1);
            }            

            // determina o bit do sinal
            if (numero >= 0)
                mantissa32[0] = false;
            else
                mantissa32[0] = true;

            // determina o valor do expoente na base 2
            bool[] expoente8bits = InteiroParaBinario(8, expoente);

            // grava o expoente na mantissa32
            for (int i = 0; i < 8; i++)
            {
                if (expoente8bits[i])
                    mantissa32[i + 1] = true;
                else
                    mantissa32[i + 1] = false;
            }

            // grava a mantissa na mantissa32
            for (int x = 0; x < resultado.Length; x++)
            {
                if (Convert.ToInt32(resultado[x]) == 49)
                    mantissa32[x + 9] = true;
                else
                    mantissa32[x + 9] = false;
            }        

            return mantissa32;
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
