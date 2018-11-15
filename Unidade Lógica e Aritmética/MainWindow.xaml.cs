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
            InitializeComponent();
        }

        #region Implementação dos botões da ULA
        //Botão a and b
        private void button_AandB_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  0  0  A and B
            bool[] f = { false, false, false }; //o contrario
            Conversor con = new Conversor();

            string A = textBoxOperando1.Text;
            string B = textBoxOperando2.Text;
            imprimirResultadoTela(encaminhaULA(f, A, B));
        }

        //Botão a or b
        private void button_AorB_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  0  1  A or B
            bool[] f = { true, false, false }; //o contrario
            Conversor con = new Conversor();

            string A = textBoxOperando1.Text;
            string B = textBoxOperando2.Text;
            imprimirResultadoTela(encaminhaULA(f, A, B));
        }

        //Botão de adição
        private void buttonSoma_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //1  0  0  A + B
            bool[] f = { false, false, true }; //o contrario
            Conversor con = new Conversor();

            string A = textBoxOperando1.Text;
            string B = textBoxOperando2.Text;
            imprimirResultadoTela(encaminhaULA(f, A, B));
        }

        //Botão de subtração
        private void buttonSubtracao_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //1  0  1  A - B ou (A + (-B))
            bool[] f = { true, false, true }; //o contrario
            Conversor con = new Conversor();

            string A = textBoxOperando1.Text;
            string B = textBoxOperando2.Text;
            imprimirResultadoTela(encaminhaULA(f, A, B));
        }

        //botão not a 
        private void button_notA_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  1  0  Not A
            bool[] f = { false, true, false }; //o contrario
            Conversor con = new Conversor();

            string A = textBoxOperando1.Text;
            string B = textBoxOperando2.Text;
            imprimirResultadoTela(encaminhaULA(f, A, B));
        }

        //botão not b
        private void button_notB_Click(object sender, RoutedEventArgs e)
        {
            //F2 F1 F0 Saída
            //0  1  1  Not B
            bool[] f = { true, true, false }; //o contrario
            Conversor con = new Conversor();

            string A = textBoxOperando1.Text;
            string B = textBoxOperando2.Text;

            imprimirResultadoTela(encaminhaULA(f, A, B));
        }
        #endregion

        #region Botões adicionais
        //Botão limpar
        private void buttonLimpar_Click(object sender, RoutedEventArgs e)
        {
            textBoxOperando1.Clear();
            textBoxOperando2.Clear();
            textBoxOperando16A.Clear();
            textBoxOperando16B.Clear();
            textBoxResultado10.Clear();
            textBoxResultado16.Clear();
            textBoxOperando1.Focus();
        }

        //Botão sair
        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Ponto Flutuante
        private bool[] chamarULAPontoFlutuante(bool f, float a, float b)
        {
            Conversor con = new Conversor();
            bool[] resultado = new bool[32];
            bool[] um = { false, false, false, false, false, false, false, true };
            UnidadeLogica8bits ula8 = new UnidadeLogica8bits();
            UnidadeLogica32PontoFlutuante ulaMantissa = new UnidadeLogica32PontoFlutuante();
            bool[] fazerSoma = { false, false, true };
            bool overSoma = false;


            //após valores convertidos 
            //separar valores

            bool sinalA = false;
            bool[] expoenteA = new bool[8];
            bool[] mantissaA = new bool[23];

            bool sinalB = false;
            bool[] expoenteB = new bool[8];
            bool[] mantissaB = new bool[23];

            while (con.imprimirBinario(expoenteA) != con.imprimirBinario(expoenteB))
            {
                if (con.BinarioParaInteiro(expoenteB) < con.BinarioParaInteiro(expoenteA))
                {
                    mantissaB = ShiftLogical.shiftRightLogical(mantissaB);
                    ula8.ULA8Bits(expoenteB, um, fazerSoma, expoenteB); //aumentar o expoente B em 1
                }
                else
                {
                    mantissaA = ShiftLogical.shiftRightLogical(mantissaA);
                    ula8.ULA8Bits(expoenteA, um, fazerSoma, expoenteA); //aumentar o expoente A em 1
                }
            }

            bool sinal;
            bool[] resultadoSomaMantissa = new bool[23];
            bool[] resultadoExpoente = new bool[8];

            if (!f) //se falso, soma
            {
                if (a > 0 && b > 0)
                {
                    sinal = false;
                    overSoma = ulaMantissa.Ativa(mantissaA, mantissaB, false, resultadoSomaMantissa);
                    resultadoExpoente = expoenteA;
                }
            }
            else //se verdadeiro, subtração
            {

            }

            bool[] resultadoFinal = new bool[32];
            //juntar
            for (int pos = 0; pos < 32; pos++)
            {

            }

            return null;
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
        private bool[] chamarULAinteiroPositivo(bool[] f, int a, int b, int tamanho)
        {
            Conversor converter = new Conversor();
            bool inverteu = false, complemento2A = false, complemento2B = false;
            bool[] A, B;
            int resposta;

            if(b>a && f[2] & !f[1] & f[0])
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
                A = converter.decimalParaComplemento2(converter.InteiroParaBinario(tamanho, a));
            }
            else
            {
                A = converter.InteiroParaBinario(tamanho, a);
            }
            if (b < 0)
            {
                b *= -1; complemento2B = true;
                B = converter.decimalParaComplemento2(converter.InteiroParaBinario(tamanho, b));
            }
            else
            {
                B = converter.InteiroParaBinario(tamanho, b);
            }

            if (f[2] & !f[1] & f[0]) //SE SUBTRAÇÃO
                B = converter.decimalParaComplemento2(B);


            bool overflowSoma;
            bool[] resultado = new bool[tamanho];

            if(tamanho == 8) //8 bits
            {
                UnidadeLogica8bits ula = new UnidadeLogica8bits();
                overflowSoma = ula.ULA8Bits(A, B, f, resultado);
            }
            else //24 bits
            {
                UnidadeLogica24bits ula = new UnidadeLogica24bits();
                overflowSoma = ula.ULA24Bits(A, B, f, resultado);
            }

            if(overflowSoma)
            {
                MessageBox.Show("Houve overflow durante a soma", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

        #region Tela
        private void imprimirResultadoTela(bool[] binario)
        {
            Conversor con = new Conversor();

            if (binario.Length == 8 || binario.Length == 24)
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
                MessageBox.Show("Não implementada");
            } 
            else
            {
                MessageBox.Show("ERROOOO");
            }
        }
        #endregion

        private bool[] encaminhaULA(bool[] f, string A, string B)
        {
            bool[] resultado = null;
            //esse método chama a ULA certa
            if (procuraVirgula(A) || (procuraVirgula(B)))
            {
                //Se existir virgula, vamos usar a ULA para numero "fracionário"
                try
                {
                    float a = float.Parse(A);
                    float b = float.Parse(B);
                    Console.WriteLine();
                    //chamar ula de 32 bits
                    resultado = chamarULAPontoFlutuante(f,a,b);
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
                            resultado = chamarULAinteiroPositivo(f, a, b, 8);
                        }
                        else if (a <= limite24bits && b <= limite24bits)
                        {
                            //ula 24 bits
                            //inteiro
                            //apenas positivos
                            resultado = chamarULAinteiroPositivo(f, a, b, 24);
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
                            resultado = chamarULAinteiroPositivo(f, a, b, 8);
                        }
                        else if (a >= minimo24bits && b >= minimo24bits && a <= maximo24bits && b <= maximo24bits)
                        {
                            //ula 24 bits
                            //inteiro
                            //negativos e positivos
                            resultado = chamarULAinteiroPositivo(f, a, b, 24);
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

        public void calcularArquivo()
        {
            string path = "operandos.txt";
            string[,] matriz = new string[100, 2];
            int posMatriz = 0;

            try
            {
                if (File.Exists(path))
                {
                    string linha;
                    string[] vetor;
                    StreamReader arquivo = new StreamReader(path);
                    
                    while (!arquivo.EndOfStream && posMatriz < 100)
                    {
                        linha = arquivo.ReadLine();
                        vetor = linha.Split(';');
                        matriz[posMatriz,0] = vetor[0];
                        Console.WriteLine(vetor[0]);
                        matriz[posMatriz,1] = vetor[1];
                        Console.WriteLine(vetor[1]);
                        posMatriz++;
                    }
                    arquivo.Close();

                    StreamWriter arqui = new StreamWriter("resultado.txt");
                    Conversor conv = new Conversor();

                    bool[] and = { false, false, false };
                    bool[] or = { true, false, false };
                    bool[] notA = { false, true, false };
                    bool[] notB = { true, true, false };
                    bool[] soma = { false, false, true };
                    bool[] sub = { true, false, true };

                    //escrever novo arquivo
                    for (int pos = 0; pos < posMatriz; pos++)
                    {
                        arqui.WriteLine("Operando A: {0}, Operando B: {1}", matriz[pos, 0], matriz[pos, 1]);
                        arqui.WriteLine("\nDECIMAL: ");
                        arqui.Write("AND: ");
                        //0  0  0  A and B
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(and, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("OR: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(or, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("NOT A: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(notA, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("NOT B: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(notB, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("SOMA: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(soma, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("SUBTRAÇÃO: ");
                        arqui.WriteLine(conv.BinarioParaInteiro(encaminhaULA(sub, matriz[pos, 0], matriz[pos, 1])));

                        arqui.WriteLine("\nHEXADECIMAL: ");
                        arqui.Write("AND: ");
                        arqui.Write(conv.BinarioParaHexadecimal(encaminhaULA(and, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("OR: ");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(or, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("NOT A: ");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(notA, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("NOT B: ");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(notB, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("SOMA: ");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(soma, matriz[pos, 0], matriz[pos, 1])));

                        arqui.Write("SUBTRAÇÃO:");
                        arqui.WriteLine(conv.BinarioParaHexadecimal(encaminhaULA(sub, matriz[pos, 0], matriz[pos, 1])));
                         

                    }
                    arqui.Close();
                }
                else { MessageBox.Show("arquivo inexistente"); }
            }
            catch(Exception e)
            {
                MessageBox.Show("Erro: " + e.Message);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calcularArquivo();
        }
    }
}
