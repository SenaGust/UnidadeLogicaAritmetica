using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Unidade_Lógica_e_Aritmética
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MessageBox.Show("A ULA possui alguns códigos da ula de ponto flutuante. Entretanto, funciona apenas 8 e 24 bits.", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);


            string programadores = "Integrantes: ";
            programadores += "\n\tGustavo Sena";
            programadores += "\n\tJoão Víctor Soares";
            programadores += "\n\tLorena Aguilar";
            programadores += "\n\tNathan Ribeiro";
            MessageBox.Show(programadores, "Programadores", MessageBoxButton.OK, MessageBoxImage.Information);

            InitializeComponent();
        }

        #region vetores usados nos decodificadores
        //Tabela inteiro
        // F2 F1 F0 Saída
        // 0  0  0  A and B
        // 0  0  1  A or B
        // 0  1  0  Not A
        // 0  1  1  Not B
        // 1  0  0  A + B
        // 1  0  1  A - B
        // 1  1  0    -
        // 1  1  1    -

        bool[] decodificadorAnd = { false, false, false };
        bool[] decodificadorOr = { true, false, false };
        bool[] decodificadorNotA = { false, true, false };
        bool[] decodificadorNotB = { true, true, false };
        bool[] decodificadorSoma = { false, false, true };
        bool[] decodificadorSubtracao = { true, false, true };
        #endregion

        #region Implementação dos botões da ULA
        private void button_AandB_Click(object sender, RoutedEventArgs e)
        {
            //Botão A and B
            imprimirResultadoTela(encaminhaULA(decodificadorAnd, textBoxOperando1.Text, textBoxOperando2.Text));
        }
        private void button_AorB_Click(object sender, RoutedEventArgs e)
        {
            //Botão A or B
            imprimirResultadoTela(encaminhaULA(decodificadorOr, textBoxOperando1.Text, textBoxOperando2.Text));
        }
        private void buttonSoma_Click(object sender, RoutedEventArgs e)
        {
            //Botão Adição
            imprimirResultadoTela(encaminhaULA(decodificadorSoma, textBoxOperando1.Text, textBoxOperando2.Text));
        }
        private void buttonSubtracao_Click(object sender, RoutedEventArgs e)
        {
            //Botão subtração
            imprimirResultadoTela(encaminhaULA(decodificadorSubtracao, textBoxOperando1.Text, textBoxOperando2.Text));
        }
        private void button_notA_Click(object sender, RoutedEventArgs e)
        {
            //Botão Not A
            imprimirResultadoTela(encaminhaULA(decodificadorNotA, textBoxOperando1.Text, textBoxOperando2.Text));
        }
        private void button_notB_Click(object sender, RoutedEventArgs e)
        {
            //botão Not B
            imprimirResultadoTela(encaminhaULA(decodificadorNotB, textBoxOperando1.Text, textBoxOperando2.Text));
        }
        #endregion

        #region Botões adicionais
        private void buttonArquivo(object sender, RoutedEventArgs e)
        {
            //botão arquivo
            calcularArquivo();
        }
        private void buttonLimpar_Click(object sender, RoutedEventArgs e)
        {
            //Botão limpar
            textBoxOperando1.Clear();
            textBoxOperando2.Clear();
            textBoxOperando16A.Clear();
            textBoxOperando16B.Clear();
            textBoxResultado10.Clear();
            textBoxResultado16.Clear();
            textBoxOperando1.Focus();
        }
        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            //botão fechar
            this.Close();
        }
        #endregion

        #region Tela
        private void imprimirResultadoTela(bool[] binario)
        {
            //consertar
            //ele mostra o resultado de -3 - 3 = 6 (deveria ser negativo)

            Conversor con = new Conversor();
            if(binario == null)
            {
                //evitar erros, pela falta de tempo não foi implementada

            }
            else if (binario.Length == 8 || binario.Length == 24)
            {
                //converter resultado pra binario
                int A = Convert.ToInt32(textBoxOperando1.Text);
                int B = Convert.ToInt32(textBoxOperando2.Text);

                if (A > 0 && B > 0)
                {
                    textBoxResultado10.Text = Convert.ToString(con.BinarioParaInteiro(binario));
                    textBoxResultado16.Text = Convert.ToString(con.BinarioParaHexadecimal(binario));

                    textBoxOperando16A.Text = Convert.ToString(con.BinarioParaHexadecimal(con.InteiroParaBinario(binario.Length, A)));
                    textBoxOperando16B.Text = Convert.ToString(con.BinarioParaHexadecimal(con.InteiroParaBinario(binario.Length, B)));
                }
                else
                {
                    int resultado = con.complemento2ParaDecimal(binario);

                    textBoxResultado10.Text = Convert.ToString(resultado);

                    if (resultado >= 0)
                        textBoxResultado16.Text = con.BinarioParaHexadecimal(con.InteiroParaBinario(binario.Length, resultado));
                    else
                        textBoxResultado16.Text = "-" + con.BinarioParaHexadecimal(con.InteiroParaBinario(binario.Length, resultado * -1));

                    if (A >= 0)
                        textBoxOperando16A.Text = Convert.ToString(con.BinarioParaHexadecimal(con.InteiroParaBinario(binario.Length, A)));
                    else
                        textBoxOperando16A.Text = "-" + Convert.ToString(con.BinarioParaHexadecimal(con.InteiroParaBinario(binario.Length, A)));

                    if (B >= 0)
                        textBoxOperando16B.Text = Convert.ToString(con.BinarioParaHexadecimal(con.InteiroParaBinario(binario.Length, B)));
                    else
                        textBoxOperando16B.Text = "-" + Convert.ToString(con.BinarioParaHexadecimal(con.InteiroParaBinario(binario.Length, B)));
                }
            }
            else if (binario.Length == 32)
            {
                // MessageBox.Show("Não implementada");
            } 
            else
            {
                MessageBox.Show("ERROOOO");
            }
        }
        #endregion

        #region Tudo sobre ULA
        private bool[] encaminhaULA(bool[] f, string A, string B)
        {
            bool[] resultado = null;
            //esse método chama a ULA certa
            if (procuraVirgula(A) || (procuraVirgula(B)))
            {
                //Se existir virgula, vamos usar a ULA para numero "fracionário"
                resultado = new bool[32];
                try
                {
                    bool implementada = true;

                    if (implementada)
                    {
                        float a = float.Parse(A);
                        float b = float.Parse(B);

                        //chamar ula de 32 bits
                        if (!f[0] & !f[1] & f[2])
                        {
                            //f = false;
                            resultado = chamarULAPontoFlutuante(false, a, b);
                        }
                        else if (f[0] & !f[1] & f[2])
                        {
                            //f = true;
                            resultado = chamarULAPontoFlutuante(true, a, b);
                        }
                        else
                        {
                            MessageBox.Show("Não é possível usar essa operação para a ULA de 32 bits", "ERRO", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Implementação da ULA de 32 bits em andamento.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
                catch (FormatException)
                {
                    MessageBox.Show("Os campos Operando 1 e/ou Operando 2 não possuem um formato correto.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Erro: Estes número não podem ser representas usando uma ULA de 32 (ponto flutuante)", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                //numero inteiro
                try
                {
                    int a = Convert.ToInt32(A);
                    int b = Convert.ToInt32(B);

                    if (a >= 0 && b >= 0)
                    {
                        double limite8bits = (Math.Pow(2, 8) - 1);
                        double limite24bits = (Math.Pow(2, 24) - 1);
                        if (a <= limite8bits && b <= limite8bits)
                        {
                            //ula 8 bits
                            //inteiro
                            //apenas positivos
                            resultado = chamarULAinteiro(f, a, b, 8);
                        }
                        else if (a <= limite24bits && b <= limite24bits)
                        {
                            //ula 24 bits
                            //inteiro
                            //apenas positivos
                            resultado = chamarULAinteiro(f, a, b, 24);
                        }
                        else
                        {
                            MessageBox.Show("Erro: não é possível representar os números informados com 24 bits.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        double maximo8bits = (Math.Pow(2, 8 - 1) - 1);
                        double minimo8bits = -(Math.Pow(2, 8 - 1));
                        double maximo24bits = (Math.Pow(2, 24 - 1) - 1);
                        double minimo24bits = -(Math.Pow(2, 24 - 1));
                        if (a >= minimo8bits && b >= minimo8bits && a <= maximo8bits && b <= maximo8bits)
                        {
                            //ula 8 bits
                            //inteiro
                            //negativos e positivos
                            resultado = chamarULAinteiro(f, a, b, 8);
                        }
                        else if (a >= minimo24bits && b >= minimo24bits && a <= maximo24bits && b <= maximo24bits)
                        {
                            //ula 24 bits
                            //inteiro
                            //negativos e positivos
                            resultado = chamarULAinteiro(f, a, b, 24);
                        }
                        else
                        {
                            MessageBox.Show("Não é possível representar esses números com a ULA de 24 bits.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch(FormatException)
                {
                    MessageBox.Show("Os campos Operando 1 e / ou Operando 2 não possuem um formato correto.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (OverflowException)
                {
                    
                    MessageBox.Show("Não é possível representar esses números com a nossa ULA.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return resultado;
        }

        #region Ponto Flutuante
        private bool[] chamarULAPontoFlutuante(bool f, float a, float b)
        {
            #region Variaveis, objetos e vetores
            //Objetos
            UnidadeLogica8bits ula8 = new UnidadeLogica8bits();
            UnidadeLogica24bits ula24 = new UnidadeLogica24bits();
            UnidadeLogica32PontoFlutuante ulaMantissa = new UnidadeLogica32PontoFlutuante();
            Conversor con = new Conversor();

            //variaveis
            int posExpoente;
            int posMantissa;

            //vetores
            bool[] expoenteUm = { false, false, false, false, false, false, false, true };

            //Ponto flutuante separado
            bool[] expoenteA = new bool[8], expoenteB = new bool[8];
            bool[] mantissaA = new bool[24], mantissaB = new bool[24];


            //números convertidos
            bool[] NumeroA = con.PontoFlutuanteParaBinario(a);
            bool[] NumeroB = con.PontoFlutuanteParaBinario(b);

            //Vetor resultado
            bool[] resultadoFinal = new bool[32];
            #endregion

            #region Separando expoente e mantissa
            posExpoente = 0;
            for (int pos = 1; pos < 9; pos++)
            {
                expoenteA[posExpoente] = NumeroA[pos];
                expoenteB[posExpoente] = NumeroB[pos];
                posExpoente++;
            }

            posMantissa = 1;
            for (int pos = 9; pos < 32; pos++)
            {
                mantissaA[posMantissa] = NumeroA[pos];
                mantissaB[posMantissa] = NumeroB[pos];
                posMantissa++;
            }
            #endregion

            #region aparecer o bit implicito
            mantissaA = ShiftLogical.shiftRightLogical(mantissaA);
            ula8.ULA8Bits(expoenteA, expoenteUm, decodificadorSoma, expoenteA); //aumentar o expoente A em 1
            mantissaB = ShiftLogical.shiftRightLogical(mantissaB);
            mantissaA[0] = true;
            mantissaB[0] = true;
            #endregion

            #region Evitar erro nas operações
            ula8.ULA8Bits(expoenteB, expoenteUm, decodificadorSoma, expoenteB); //aumentar o expoente B em 1
            mantissaA = ShiftLogical.shiftRightLogical(mantissaA);
            ula8.ULA8Bits(expoenteA, expoenteUm, decodificadorSoma, expoenteA); //aumentar o expoente A em 1
            mantissaB = ShiftLogical.shiftRightLogical(mantissaB);
            ula8.ULA8Bits(expoenteB, expoenteUm, decodificadorSoma, expoenteB); //aumentar o expoente B em 1
            #endregion

            #region igualar o expoente
            while (con.imprimirBinario(expoenteA) != con.imprimirBinario(expoenteB))
            {
                if (con.BinarioParaInteiro(expoenteB) < con.BinarioParaInteiro(expoenteA))
                {
                    mantissaB = ShiftLogical.shiftRightLogical(mantissaB);
                    ula8.ULA8Bits(expoenteB, expoenteUm, decodificadorSoma, expoenteB); //aumentar o expoente B em 1
                }
                else
                {
                    mantissaA = ShiftLogical.shiftRightLogical(mantissaA);
                    ula8.ULA8Bits(expoenteA, expoenteUm, decodificadorSoma, expoenteA); //aumentar o expoente A em 1
                }
            }
            
            #endregion

            #region Fazer soma ou subtração
            bool[] resultadoSomaMantissa = new bool[24];
            bool[] resultadoExpoente = new bool[8];

            if (!f) //se falso, soma
            {
                if (a > 0 && b > 0)
                {
                    ula24.ULA24Bits(mantissaA, mantissaB, decodificadorSoma, resultadoSomaMantissa);
                    resultadoExpoente = expoenteA;
                }
            }
            else //se verdadeiro, subtração
            {
                if (a > 0 && b > 0)
                {
                    ula24.ULA24Bits(mantissaA, con.complemento2(mantissaB), decodificadorSubtracao, resultadoSomaMantissa);
                    resultadoExpoente = expoenteA;

                }
            }
            #endregion

            #region teste
            Console.WriteLine("Teste A");
            Console.WriteLine(con.imprimirBinario(mantissaA));

            Console.WriteLine("Teste B");
            Console.WriteLine(con.imprimirBinario(mantissaB));

            Console.WriteLine("Resultado resultadoSomaMantissa");
            Console.WriteLine(con.imprimirBinario(resultadoSomaMantissa));
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Reunir para o vetor resultado final
            posExpoente = 0;
            for (int pos = 1; pos < 9; pos++)
            {
                resultadoFinal[pos] = resultadoExpoente[posExpoente];
                posExpoente++;
            }


            posMantissa = 0;
            resultadoSomaMantissa[1] = true;
            for (int pos = 9; pos < 32; pos++)
            {
                resultadoFinal[pos] = resultadoSomaMantissa[posMantissa];
                posMantissa++;
            }
            #endregion

            textBoxResultado10.Text = con.BinarioParaPontoFlutuante(resultadoFinal) + " ";
            textBoxOperando16A.Text = con.BinarioParaPontoFlutuante(NumeroA) + " ";
            textBoxOperando16B.Text = con.BinarioParaPontoFlutuante(NumeroB) + " ";

            #region teste
            Console.WriteLine("Teste A");
            for (int g = 0; g < NumeroA.Length; g++)
            {
                if (NumeroA[g])
                    Console.Write("1 ");
                else
                    Console.Write("0 ");

                if (g == 0 || g == 8)
                    Console.Write("- ");
            }
            Console.WriteLine();
            

            Console.WriteLine("Teste B");
            for (int g = 0; g < NumeroB.Length; g++)
            {
                if (NumeroB[g])
                    Console.Write("1 ");
                else
                    Console.Write("0 ");

                if (g == 0 || g == 8)
                    Console.Write("- ");
            }
            Console.WriteLine();

            Console.WriteLine("Resultado");
            for (int g = 0; g < resultadoFinal.Length; g++)
            {
                if (resultadoFinal[g])
                    Console.Write("1 ");
                else
                    Console.Write("0 ");

                if (g == 0 || g == 8)
                    Console.Write("- ");
            }
            Console.WriteLine();
            #endregion

            return resultadoFinal;
        }
        private bool procuraVirgula(string numero)
        {
            for (int pos = 0; pos < numero.Length; pos++)
            {
                if (numero[pos] == ',')
                    return true;
            }

            return false;
        }
        #endregion

        #region Inteiro
        private bool[] chamarULAinteiro(bool[] f, int a, int b, int tamanho)
        {
            Conversor converter = new Conversor();
            bool inverteu = false, complemento2A = false, complemento2B = false;
            bool[] A, B;
            int resposta;

            if (b > a && f[2] & !f[1] & f[0]) //caso seja soma ou subtração e b seja > a ele inverte
            {
                inverteu = true;
                int aux = a;
                a = b;
                b = aux;
            }

            //convertendo pra complemento 2 binario
            if (a < 0)
            {
                a *= -1; complemento2A = true;
                A = converter.complemento2(converter.InteiroParaBinario(tamanho, a));
            }
            else
            {
                A = converter.InteiroParaBinario(tamanho, a);
            }
            if (b < 0)
            {
                b *= -1; complemento2B = true;
                B = converter.complemento2(converter.InteiroParaBinario(tamanho, b));
            }
            else
            {
                B = converter.InteiroParaBinario(tamanho, b);
            }

            if (f[2] & !f[1] & f[0]) //SE SUBTRAÇÃO
                B = converter.complemento2(B);


            bool overflowSoma;
            bool[] resultado = new bool[tamanho];

            if (tamanho == 8) //8 bits
            {
                UnidadeLogica8bits ula = new UnidadeLogica8bits();
                overflowSoma = ula.ULA8Bits(A, B, f, resultado);
            }
            else //24 bits
            {
                UnidadeLogica24bits ula = new UnidadeLogica24bits();
                overflowSoma = ula.ULA24Bits(A, B, f, resultado);
            }

            //if(overflowSoma)
            //{
            //    MessageBox.Show("Houve overflow durante a soma", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

            //resultado
            if (complemento2A || complemento2B)
                resposta = converter.complemento2ParaDecimal(resultado);
            else
                resposta = converter.BinarioParaInteiro(resultado);


            if (inverteu)
            {
                resposta *= -1;
            }
            return resultado;
        }
        #endregion
        #endregion

        #region arquivo
        public void calcularArquivo()
        {
            string path = "operandos.txt";
            string OperandoA, OperandoB;

            try
            {
                if (File.Exists(path))
                {
                    string[] linha;
                    StreamReader arquivo = new StreamReader(path); //Stream de leitura do arquivo contendo os operandos
                    StreamWriter arqui = new StreamWriter("resultado.txt"); //Stream de escrita do arquivo com os resultados das operações com os operandos

                    Conversor conv = new Conversor();

                    //escrever novo arquivo
                    for (int pos = 0; !arquivo.EndOfStream; pos++)
                    {
                        linha = arquivo.ReadLine().Split(';'); //Lê uma linha do arquivo e separa pelo separador ';' no vetor linha
                        OperandoA = linha[0]; //atribui a primeira posição do vetor linha
                        OperandoB = linha[1]; ////atribui a segunda posição do vetor linha

                        //Executa os cálculos e salva os resultados no arquivo "resultado.txt"
                        arqui.WriteLine("Operando A: {0}, Operando B: {1}", OperandoA, OperandoB);
                        arqui.WriteLine("\tDECIMAL: ");
                        arqui.Write("AND: ");
                        //0  0  0  A and B                        
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(decodificadorAnd, OperandoA, OperandoB)));

                        arqui.Write("OR: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(decodificadorOr, OperandoA, OperandoB)));

                        arqui.Write("NOT A: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(decodificadorNotA, OperandoA, OperandoB)));

                        arqui.Write("NOT B: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(decodificadorNotB, OperandoA, OperandoB)));

                        arqui.Write("SOMA: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(decodificadorSoma, OperandoA, OperandoB)));

                        arqui.Write("SUBTRAÇÃO: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(decodificadorSubtracao, OperandoA, OperandoB)));

                        arqui.WriteLine("\tHEXADECIMAL: ");
                        arqui.Write("AND: ");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(decodificadorAnd, OperandoA, OperandoB)));

                        arqui.Write("OR: ");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(decodificadorOr, OperandoA, OperandoB)));

                        arqui.Write("NOT A: ");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(decodificadorNotA, OperandoA, OperandoB)));

                        arqui.Write("NOT B: ");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(decodificadorNotB, OperandoA, OperandoB)));

                        arqui.Write("SOMA: ");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(decodificadorSoma, OperandoA, OperandoB)));

                        arqui.Write("SUBTRAÇÃO:");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(decodificadorSubtracao, OperandoA, OperandoB)));

                        arqui.WriteLine();
                        arqui.WriteLine();
                        arqui.WriteLine();
                    }
                    arqui.Close();
                    arquivo.Close();
                    MessageBox.Show("De acordo com o arquivo operandos.txt foi gerado um novo arquivo com os resultados chamado resultado.txt", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else { MessageBox.Show("arquivo inexistente"); }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro: " + e.Message);
            }
        }
        #endregion
    }
}
